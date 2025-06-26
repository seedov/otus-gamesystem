using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    private void Start()
    {
        var listeners = GetComponentsInChildren<IGameEventListener>();
        var gameCycle = GetComponent<GameCycle>();
        foreach (var listener in listeners)
            gameCycle.AddListener(listener);

        var updatables = GetComponentsInChildren<ICustomUpdatable>();
        var gameUpdater = GetComponent<GameUpdater>();
        foreach (var updatable in updatables)
            gameUpdater.AddUpdatable(updatable);

        var pausableUpdatables = GetComponentsInChildren<IPausableUpdatable>();
        foreach (var updatable in pausableUpdatables)
            gameUpdater.AddUpdatable(updatable);
    }
}
