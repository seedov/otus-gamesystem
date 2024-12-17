using UnityEngine;

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    Finished
}

public class GameStateController : MonoBehaviour
{
    public GameState state;

    private IGameStateListener[] gameStateListeners;

    private void Awake()
    {
        gameStateListeners = transform.parent.GetComponentsInChildren<IGameStateListener>();
    }

    [ContextMenu("Start")]
    public void StartGame()
    {
        if (state == GameState.MainMenu || state == GameState.Paused)
        {
            state = GameState.Playing;
            foreach (var listener in gameStateListeners)
            {
                if(listener is IStartGameListener startGameListener)
                {
                    startGameListener.StartGame();
                }
            }
        }
    }

    [ContextMenu("Pause")]
    public void PauseGame()
    {
        if (state == GameState.Playing)
        {
            state = GameState.Paused;
            foreach (var listener in gameStateListeners)
            {
                if (listener is IPauseGameListener l)
                {
                    l.PauseGame();
                }
            }
        }
    }

    [ContextMenu("Resume")]
    public void ResumeGame()
    {
        if (state == GameState.Paused)
        {
            state = GameState.Playing;
            foreach (var listener in gameStateListeners)
            {
                if (listener is IResumeGameListener l)
                {
                    l.ResumeGame();
                }
            }
        }
    }

    [ContextMenu("Finish")]
    public void FinishGame()
    {
        if (state == GameState.Paused || state == GameState.Playing)
        {
            state = GameState.Finished;
            foreach (var listener in gameStateListeners)
            {
                if (listener is IFinishGameListener l)
                {
                    l.FinishGame();
                }
            }
        }
    }
}
