using Domain;

namespace GraphQL.Types;

public sealed class NResultGraphType<TValue>:ObjectGraphType<NoGenericResult<TValue>>
{
    public NResultGraphType()
    {
        Field(x => x.Error);
        
        Field(x => x.IsSuccess);
        
        Field(x => x.IsFailure);
        
        Field(x => x.Value);
    }
}