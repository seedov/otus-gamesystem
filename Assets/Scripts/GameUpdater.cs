using System.Collections.Generic;
using UnityEngine;

public class GameUpdater : MonoBehaviour, IStartGameListener, IPauseGameListener, IResumeGameListener, IFinishGameListener
{
    private List<ICustomUpdatable> updatables = new();
    private List<IPausableUpdatable> pausableUpdatables = new();

    public void AddUpdatable(ICustomUpdatable updatable)
    {
        updatables.Add(updatable);
    }

    public void AddUpdatable(IPausableUpdatable updatable)
    {
        pausableUpdatables.Add(updatable);
    }

    private bool isActive;

    void IFinishGameListener.FinishGame()
    {
        isActive = false;
    }

    void IPauseGameListener.PauseGame()
    {
        isActive = false;
    }

    void IResumeGameListener.ResumeGame()
    {
        isActive = true;
    }

    void IStartGameListener.StartGame()
    {
        isActive = true;
    }

    private void Update()
    {
        foreach(var updatable in updatables)
        {
            updatable.CustomUpdate();
        }
        if (isActive)
        {
            foreach (var updatable in pausableUpdatables)
            {
                updatable.PausableUpdate();
            }
        }
    }
}
