namespace Domain;

public class Result<TValue, TError>
{
    private TValue? _value;

    public TValue? Data { get; private set; }
    
    public List<TError> Errors { get; }

    public bool  IsSuccess { get; private set; }

    private Result(TValue value)
    {
        Errors = [];
        _value = value;
    }
    
    
    public static Result<TValue,TError> Instance(TValue value) => new(value);
    
    public Result<TValue, TError> ErrorCase(Func<TValue,bool> predicate,TError error)
    {
        if (predicate(_value!))
        {
            Errors.Add(error);
        }
        return this;
    }

    public Result<TValue, TError> GetResult()
    {
        if (Errors.Count == 0)
        {
            Data = _value;
            IsSuccess = true;
        }
        else
        {
            IsSuccess = false;
        }
        
        return this;
    }
    
}
