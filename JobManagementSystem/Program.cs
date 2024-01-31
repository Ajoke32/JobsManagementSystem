using System.Text.Json;
using Domain.Models;
using GraphQL.Extensions;
using Infrastructure.Extensions;
using Infrastructure.Messaging.SSE;
using Infrastructure.Messaging.SSE.Abstraction;
using JobManagementSystem.Selenium.Abstraction;
using JobManagementSystem.Selenium.Abstraction.Template;
using JobManagementSystem.Selenium.Core;
using JobManagementSystem.Selenium.Options;
using Microsoft.Net.Http.Headers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Vite.AspNetCore.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSpaStaticFiles(c =>
{
    c.RootPath = "clientApp/build";
});


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddViteServices(conf =>
    {
        conf.PackageManager = "npm";
        conf.Server.Port = 5173;
        conf.Server.ScriptName = "dev";
        conf.Server.AutoRun = true;
        conf.Server.TimeOut = 15;
        conf.PackageDirectory = "clientApp";
    });
}

builder.Services.AddInfrastructure();

builder.Services.AddGraphQlServices();

builder.Services.AddScoped<IParsingTemplate, ParsingTemplate>();

builder.Services.AddSingleton<IWebDriver, ChromeDriver>();

builder.Services.AddScoped<IParserApp, ParsingApp>();


var app = builder.Build();


app.UseSpaStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseGraphQLAltair();
}

app.MapPost("/parse",  async (pr) =>
{

    var requestBody = await new StreamReader(pr.Request.Body).ReadToEndAsync(); 
    
    var requestOptions = JsonSerializer.Deserialize<ParsingAppOption>(requestBody);
    
    var parserApp = pr.RequestServices.GetRequiredService<IParserApp>();
    
    parserApp.ConfigureParsingOptions((options) =>
    {
        options = requestOptions ?? DefaultParsingOptions.GetDefaultParsingAppOption;

        return options;
    });
    
    await parserApp.StartAsync();
});


app.MapGet("/message", async (
    HttpContext ctx,
    ISSENotifier<NotificationBase> service,
    CancellationToken token) =>
{
    ctx.Response.Headers.ContentType = "text/event-stream";

    while (!token.IsCancellationRequested)
    {
        var item = await service.WaitForNotification();
        await ctx.Response.WriteAsync($"data:", cancellationToken: token);
        await JsonSerializer.SerializeAsync(ctx.Response.Body, item, cancellationToken: token);
        await ctx.Response.WriteAsync("\n\n", cancellationToken: token);
        await ctx.Response.Body.FlushAsync(token);

        service.Reset();
    }
});

app.UseGraphQL();

app.UseSpa(spa =>
{
    
    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
        {
            var headers = ctx.Context.Response.GetTypedHeaders();
            headers.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true,
                NoStore = true,
                MustRevalidate = true
            };
        }
    };
    
    if (app.Environment.IsDevelopment())
    {
       app.UseViteDevMiddleware();
    }
});



app.Run();