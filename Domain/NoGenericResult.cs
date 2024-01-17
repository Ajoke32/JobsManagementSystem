namespace Domain;

public class NoGenericResult<TValue>
{
    
    private NoGenericResult(bool isSuccess, string error, TValue? value)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }
    
    public TValue? Value { get; }
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;
    public string Error { get; }
    
    public static NoGenericResult<TValue> Success(TValue value) => new(true, "",value);
    
    public static NoGenericResult<TValue> Failure(string error) => new(false, error,default);

    public static NoGenericResult<TValue> Match(Func<TValue, bool> predicate, TValue value)
    {
        if (predicate(value))
        {
            return Success(value);
        }
        
        return Failure("Users not found");
    }
   
    
}