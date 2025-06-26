
public interface IGameEventListener { }
public interface IStartGameListener: IGameEventListener
{
    public void StartGame();
}
public interface IPauseGameListener : IGameEventListener
{
    public void PauseGame();
}
public interface IResumeGameListener : IGameEventListener
{ 
    public void ResumeGame();
}

public interface IFinishGameListener : IGameEventListener
{
    public void FinishGame();
}


public interface ICustomUpdatable
{
    public void CustomUpdate();
}

public interface IPausableUpdatable
{
    public void PausableUpdate();
}