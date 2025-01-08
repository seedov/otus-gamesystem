using Lessons.Architecture.VContainer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class GameUI : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private GameController gameController;
    private IHealthComponent healthComponent;

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button pauseButton;    
    
    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private TMP_Text hpText;

    [Inject]
    private void Construct(GameController gameController, IHealthComponent healthComponent)
    {
        this.gameController = gameController;
        this.healthComponent = healthComponent;
        healthComponent.HpChanged += HealthComponent_HpChanged;
    }

    private void HealthComponent_HpChanged(float hp)
    {
        hpText.text = healthComponent.Hp.ToString();
    }

    private void EnablePlayButton()
    {
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    private void EnablePauseButton()
    {
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }
    private void EnableResumeButton()
    {
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    private void Start()
    {
        EnablePlayButton();
        playButton.onClick.AddListener(ProcessPlayButtonClick);
        pauseButton.onClick.AddListener(ProcessPauseButtonClick);
        resumeButton.onClick.AddListener(ProcessResumeButtonClick);
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        pauseButton.onClick.RemoveAllListeners();
        resumeButton.onClick.RemoveAllListeners();
    }
    private void ProcessResumeButtonClick()
    {
        gameController.ResumeGame();

        EnablePauseButton();
    }
    private void ProcessPlayButtonClick()
    {
        gameController.StartGame();

        EnablePauseButton();
    }
    private void ProcessPauseButtonClick()
    {
        gameController.PauseGame();
        EnableResumeButton();
    }

    void IStartGameListener.StartGame()
    {
        gameObject.SetActive(true);
        hpText.text = healthComponent.Hp.ToString();
    }

    void IFinishGameListener.FinishGame()
    {
        gameObject.SetActive(false);
    }
}
