using GraphQL.Operations;
using GraphQL.Operations.Queries;
using GraphQL.Schemes;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddGraphQlServices(this IServiceCollection services)
    {
        services.AddScoped<RootMutation>();
        
        services.AddScoped<RootQuery>();
        
        services.AddGraphQL(conf =>
        {
            conf.AddAutoClrMappings()
                .AddSchema<AppScheme>(GraphQL.DI.ServiceLifetime.Scoped)
                .AddErrorInfoProvider(e =>
                    e.ExposeExceptionDetails = true
                )
                .AddSystemTextJson()
                .AddGraphTypes();
        });
    }
}