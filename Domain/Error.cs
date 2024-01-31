namespace Domain;

public class Error(string code, string? message = null)
{
    public string Code => code;
    
    public string? Message => message;
}