using Domain;

namespace GraphQL.Types;

public sealed class ResultGraphType<TValue,TError>:ObjectGraphType<Result<TValue,TError>>
{
    public ResultGraphType()
    {
        Field(x => x.Error);
        
        Field(x => x.Value);
        
        Field(x => x.IsSuccess);
    }
    
}