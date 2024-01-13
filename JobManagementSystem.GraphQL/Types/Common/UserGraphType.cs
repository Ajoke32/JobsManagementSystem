using Domain.Models;

namespace GraphQL.Types.Common;

public sealed class UserGraphType:ObjectGraphType<User>
{
    public UserGraphType()
    {
        Field(x=>x.Id).Description("Users Id");
        
        Field(x=>x.Email).Description("Users Email");
        
        Field(x=>x.IsNotificationsAllowed).Description("Users Notifications Allowed");
        
        Field(x => x.IsEmailMailingAllowed).Description("Users Email Mailing Allowed");
        
        Field(x => x.JobPosition).Description("Users Job Position");
    }
}