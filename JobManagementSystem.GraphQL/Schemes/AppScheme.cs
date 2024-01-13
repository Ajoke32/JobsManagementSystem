using GraphQL.Operations;
using GraphQL.Types;

namespace GraphQL.Schemes;

public class AppScheme:Schema
{

    public AppScheme(IServiceProvider provider, RootMutation mutation, RootQuery query):base(provider)
    {
        Query = query;
        Mutation = mutation;
    }
}