using Application.Abstraction.UnitOfWork;
using Domain;
using Domain.Errors;
using Domain.Models;
using GraphQL.Types;
using GraphQL.Types.Common;

namespace GraphQL.Operations.Queries;

public sealed class UserQuery:ObjectGraphType
{
    public UserQuery(IUnitOfWork uow)
    {
        var userRepos = uow.GenericRepository<User>();
        
        Field<NResultGraphType<List<User>>>("all")
            .ResolveAsync(async _ =>
            {
                var users = await userRepos.GetAsync();
                
                return NoGenericResult<List<User>>.Match(
                    predicate:(u)=>u.Count >3 ,
                    users.ToList()
                    );
            });
    }
    
}