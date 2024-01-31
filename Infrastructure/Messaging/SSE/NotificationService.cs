using Infrastructure.Messaging.SSE.Abstraction;

namespace Infrastructure.Messaging.SSE;

public class NotificationService<T>:ISSENotifier<T>
{
    private TaskCompletionSource<T> _tcs = new();

    public void Notify(T value)
    {
        _tcs.TrySetResult(value);
    }

    public void Reset()
    {
        _tcs = new TaskCompletionSource<T>();
    }
    
    public Task<T> WaitForNotification()
    {
        
        return _tcs.Task;
    }
}