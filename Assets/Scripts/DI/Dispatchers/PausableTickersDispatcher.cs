using System.Collections.Generic;
using VContainer.Internal;
using VContainer.Unity;
using VContainer;

public interface IPauseTickable
{
    public void Tick();
}
public interface IScopeDispatcher
{
    void StartDispatching(IObjectResolver container);
    void StopDispatching(IObjectResolver container);
}
public class PausableTickersDispatcher : IScopeDispatcher, ITickable, IPauseGameListener, IResumeGameListener, IStartGameListener, IFinishGameListener
{
    private List<IPauseTickable> pauseTickables = new List<IPauseTickable>() ;
    private bool canTick;


    public void StartDispatching(IObjectResolver container)
    {
        var tickables  = container.Resolve<ContainerLocal<IReadOnlyList<IPauseTickable>>>().Value;
        pauseTickables.AddRange(tickables);
    }

    public void StopDispatching(IObjectResolver container)
    {
        var tickables = container.Resolve<ContainerLocal<IReadOnlyList<IPauseTickable>>>().Value;
        foreach(var tickable in tickables)
            pauseTickables.Remove(tickable);
    }

    void ITickable.Tick()
    {
        if (!canTick)
            return;
        for(var i =0; i<pauseTickables.Count; ++i)
        {
            var pauseTickable = pauseTickables[i];
            if(pauseTickable.ToString() !="null")
            pauseTickable.Tick();
        }
    }

    void IPauseGameListener.PauseGame()
    {
        canTick = false;
    }

    void IResumeGameListener.ResumeGame()
    {
        canTick = true;
    }

    void IStartGameListener.StartGame()
    {
        canTick = true;
    }

    void IFinishGameListener.FinishGame()
    {
        canTick = false;
    }
}

