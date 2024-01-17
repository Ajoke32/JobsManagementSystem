using GraphQL.Extensions;
using Infrastructure.Extensions;
using Microsoft.Net.Http.Headers;
using Vite.AspNetCore.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSpaStaticFiles(c =>
{
    c.RootPath = "clientApp/build";
});


/*if (builder.Environment.IsDevelopment())
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
}*/

builder.Services.AddInfrastructure();

builder.Services.AddGraphQlServices();

var app = builder.Build();


app.UseSpaStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseGraphQLAltair();
}

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
       // app.UseViteDevMiddleware();
    }
});



app.Run();