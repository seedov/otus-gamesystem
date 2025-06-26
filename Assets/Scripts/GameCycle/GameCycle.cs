using System;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None,
    Playing,
    Paused,
    Finished
}

public class GameCycle : MonoBehaviour
{
    private List<IStartGameListener> startGameListeners = new();
    private List<IPauseGameListener> pauseGameListeners = new();
    private List<IResumeGameListener> resumeGameListeners = new();
    private List<IFinishGameListener> finishGameListeners = new();

    private GameState gameState;
    public void AddListener(IGameEventListener listener)
    {
        if(listener is IStartGameListener startGameListener)
            startGameListeners.Add(startGameListener);
        if (listener is IPauseGameListener pauseGameListener)
            pauseGameListeners.Add(pauseGameListener);
        if (listener is IResumeGameListener resumeGameListener)
            resumeGameListeners.Add(resumeGameListener);
        if (listener is IFinishGameListener finishGameListener)
            finishGameListeners.Add(finishGameListener);
    }

    [ContextMenu("Start game")]
    public void StartGame()
    {
        if (gameState == GameState.Playing)
            return;
        gameState = GameState.Playing;

        foreach (IStartGameListener listener in startGameListeners)
        {
            listener.StartGame();
        }
    }
    [ContextMenu("Pause game")]
    public void PauseGame()
    {
        if (gameState != GameState.Playing)
            return;
        gameState = GameState.Paused;

        foreach (IPauseGameListener listener in pauseGameListeners)
        {
            listener.PauseGame();
        }
    }
    [ContextMenu("Resume game")]
    public void ResumeGame()
    {
        if(gameState != GameState.Paused)
            return;
        gameState = GameState.Playing;
        foreach (IResumeGameListener listener in resumeGameListeners)
        {
            listener.ResumeGame();
        }
    }
    [ContextMenu("Finish game")]
    public void FinishGame()
    {
        if(gameState == GameState.Finished) return;
        gameState = GameState.Finished;

        foreach (IFinishGameListener listener in finishGameListeners)
        {
            listener.FinishGame();
        }
    }

}
