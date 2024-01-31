namespace Domain.Errors;

public static class UserErrors
{
    public static Error UsersNotFound => new("Users.NotFound","Users not found");
}