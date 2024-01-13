using GraphQL.Operations.Queries;
using GraphQL.Types;

namespace GraphQL.Operations;

public sealed class RootQuery:ObjectGraphType
{
    public RootQuery()
    {
        Field<UserQuery>("users")
            .Resolve(_ => new {  });
    }
}