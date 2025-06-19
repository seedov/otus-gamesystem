using Lessons.Architecture.VContainer;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class GameOverScreen : MonoBehaviour, IFinishGameListener, IStartGameListener, IInitializable
{
    [SerializeField]
    private Button replayButton;


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
