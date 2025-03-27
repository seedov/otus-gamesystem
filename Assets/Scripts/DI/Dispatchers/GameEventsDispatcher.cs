using System.Collections.Generic;
using VContainer;
using VContainer.Internal;
using VContainer.Unity;
public class GameEventsDispatcher: IScopeDispatcher, IInitializable
{
    private List<IPauseGameListener> pauseGameListeners = new();
    private List<IResumeGameListener> resumeGameListeners = new();
    private List<IStartGameListener> startGameListeners = new();
    private List<IFinishGameListener> finishGameListeners = new();

    public GameEventsDispatcher(IReadOnlyList<IGameEventListener> gameEventListeners)
    {
        AddRegistrations(gameEventListeners);
    }

    public void Initialize()
    {

    }

    void IScopeDispatcher.StartDispatching(IObjectResolver container)
    {
        var thisScopeGameEventListeners = container.Resolve<ContainerLocal<IReadOnlyList<IGameEventListener>>>().Value;
        AddRegistrations(thisScopeGameEventListeners);
    }

    void IScopeDispatcher.StopDispatching(IObjectResolver container)
    {
        var thisScopeGameEventListeners = container.Resolve<ContainerLocal<IReadOnlyList<IGameEventListener>>>().Value;
        RemoveRegistrations(thisScopeGameEventListeners);
    }

    private void AddRegistrations(IReadOnlyList<IGameEventListener> gameEventListeners)
    {
        foreach(var listener in gameEventListeners)
        {
            if (listener is IPauseGameListener pauseListener)
                pauseGameListeners.Add(pauseListener);
            if (listener is IStartGameListener startListener)
                startGameListeners.Add(startListener);
            if (listener is IResumeGameListener resumeListener)
                resumeGameListeners.Add(resumeListener);
            if (listener is IFinishGameListener finishListener)
                finishGameListeners.Add(finishListener);
        }
    }

    private void RemoveRegistrations(IReadOnlyList<IGameEventListener> gameEventListeners)
    {
        foreach (var listener in gameEventListeners)
        {
            if (listener is IPauseGameListener pauseListener)
                pauseGameListeners.Remove(pauseListener);
            if (listener is IStartGameListener startListener)
                startGameListeners.Remove(startListener);
            if (listener is IResumeGameListener resumeListener)
                resumeGameListeners.Remove(resumeListener);
            if (listener is IFinishGameListener finishListener)
                finishGameListeners.Remove(finishListener);
        }
    }

    public void StartGame()
    {
        foreach (var listener in startGameListeners)
        {
            listener.StartGame();
        }
    }

    public void PauseGame()
    {
        foreach (var listener in pauseGameListeners)
        {
            listener.PauseGame();
        }
    }

    public void ResumeGame()
    {
        foreach (var listener in resumeGameListeners)
        {
            listener.ResumeGame();
        }
    }

    public void FinishGame()
    {
        foreach (var listener in finishGameListeners)
        {
            listener.FinishGame();
        }
    }


}
