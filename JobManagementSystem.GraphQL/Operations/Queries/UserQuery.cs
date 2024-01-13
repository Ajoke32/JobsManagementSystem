using Application.Abstraction.UnitOfWork;
using Domain.Models;
using GraphQL.Types;
using GraphQL.Types.Common;

namespace GraphQL.Operations.Queries;

public sealed class UserQuery:ObjectGraphType
{
    public UserQuery(IUnitOfWork uow)
    {
        var userRepos = uow.GenericRepository<User>();
        
        Field<ListGraphType<UserGraphType>>("all")
            .ResolveAsync(async _ =>
            {
                var users = await userRepos.GetAsync();

                return users.ToList();
            });
    }
}