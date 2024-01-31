namespace Infrastructure.Messaging.SSE.Abstraction;

public interface ISSENotifier<TItem>
{
    public void Reset();

    public void Notify(TItem value);

    public Task<TItem> WaitForNotification();
}