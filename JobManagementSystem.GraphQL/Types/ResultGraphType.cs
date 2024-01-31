using Domain;

namespace GraphQL.Types;

public sealed class ResultGraphType<TValue,TError>:ObjectGraphType<Result<TValue,TError>>
{
    public ResultGraphType()
    {
        Field(x => x.Errors);
        
        Field(x => x.Data,nullable:true);
        
        Field(x => x.IsSuccess);
    }
    
}