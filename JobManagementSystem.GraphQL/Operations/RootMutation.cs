using GraphQL.Types;

namespace GraphQL.Operations;

public class RootMutation:ObjectGraphType
{
    public RootMutation()
    {
        Field<string>("createName")
            .Resolve(_ =>
            {
                return "string";
            });
    }
}