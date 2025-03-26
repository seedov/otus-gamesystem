using Lessons.Architecture.VContainer;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class GameOverScreen : MonoBehaviour, IFinishGameListener, IStartGameListener, IInitializable
{
    [SerializeField]
    private Button replayButton;

    [Inject]
    private GameController gameController;

    void IInitializable.Initialize()
    {
        gameObject.SetActive(false);
    }

    void IFinishGameListener.FinishGame()
    {
        gameObject.SetActive(true);
    }

    void IStartGameListener.StartGame()
    {
        gameObject.SetActive(false);
    }

    private void OnReplayButtonClicked()
    {
        gameController.StartGame();
    }

    private void OnEnable()
    {
        replayButton.onClick.AddListener(OnReplayButtonClicked);
    }
    private void OnDisable()
    {
        replayButton.onClick.RemoveAllListeners();
    }


}
