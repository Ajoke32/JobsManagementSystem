namespace Domain;

public class Result<TValue, TError>
{
    public TValue? Value { get; }

    public TError? Error { get; }
    
    public bool  IsSuccess { get; }

    private Result(TValue value)
    {
        Value = value;
        IsSuccess = true;
        Error = default;
    }

    private Result(TError error)
    {
        Error = error;
        IsSuccess = false;
        Value = default;
    }
    
    public static implicit operator Result<TValue,TError>(TValue value) => new(value);
    
    public static implicit operator Result<TValue,TError>(TError error) => new(error);
    
    public Result<TValue, TError> Match(Func<TValue, Result<TValue, TError>> success, Func<TError, Result<TValue, TError>> failure)
    {
        if (IsSuccess)
        {
            return success(Value!);
        }
        return failure(Error!);
    }
}