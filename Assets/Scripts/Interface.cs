using UnityEngine;

public interface IUserInputListener
{
    void UserInputReceived(Vector2 input);
}

public interface IGameStateListener { }

public interface IStartGameListener: IGameStateListener
{
    void StartGame();
}

public interface IPauseGameListener: IGameStateListener
{
    void PauseGame();
}

public interface IResumeGameListener: IGameStateListener
{
    void ResumeGame();
}

public interface IFinishGameListener: IGameStateListener
{
    void FinishGame();
}

public interface IUpdatable
{
    void CustomUpdate();
}


