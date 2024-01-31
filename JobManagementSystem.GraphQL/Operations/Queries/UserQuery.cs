using Application.Abstraction.UnitOfWork;
using Domain;
using Domain.Errors;
using Domain.Models;
using GraphQL.Types;


namespace GraphQL.Operations.Queries;

public sealed class UserQuery:ObjectGraphType
{
    public UserQuery(IUnitOfWork uow)
    {
        var userRepos = uow.GenericRepository<User>();
        
        Field<ResultGraphType<List<User>,Error>>("all")
            .ResolveAsync(async _ =>
            {
                var users = await userRepos.GetAsync();

                return Result<List<User>, Error>
                    .Instance(users.ToList())
                    .ErrorCase(val => val.Count == 0, UserErrors.UsersNotFound)
                    .GetResult();
            });
    }
    
}