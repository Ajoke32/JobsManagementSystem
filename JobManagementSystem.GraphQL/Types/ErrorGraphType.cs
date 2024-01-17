using Domain;

namespace GraphQL.Types;

public sealed class ErrorGraphType:ObjectGraphType<Error>
{
    public ErrorGraphType()
    {
        Field(x => x.Code);
        
        Field(x => x.Message);
    }
}