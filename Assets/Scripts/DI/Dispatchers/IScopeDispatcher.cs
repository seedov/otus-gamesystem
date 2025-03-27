using VContainer;

public interface IScopeDispatcher
{
    void StartDispatching(IObjectResolver container);
    void StopDispatching(IObjectResolver container);
}

