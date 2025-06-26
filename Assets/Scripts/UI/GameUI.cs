using System;
using Lessons.Architecture.VContainer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;
public class GameUI : MonoBehaviour, IStartGameListener, IFinishGameListener
{

    [SerializeField]
    private GameCycle gameCycle;

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button pauseButton;    
    
    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private TMP_Text hpText;



    private void EnablePlayButton()
    {
        background.SetActive(true);
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    private void EnablePauseButton()
    {
        background.SetActive(false );
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }
    private void EnableResumeButton()
    {
        background.SetActive(false );
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    void Awake()
    {
        EnablePlayButton();
        playButton.onClick.AddListener(ProcessPlayButtonClick);
        pauseButton.onClick.AddListener(ProcessPauseButtonClick);
        resumeButton.onClick.AddListener(ProcessResumeButtonClick);
    }

    void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        pauseButton.onClick.RemoveAllListeners();
        resumeButton.onClick.RemoveAllListeners();
    }
    private void ProcessResumeButtonClick()
    {
        EnablePauseButton();
        gameCycle.ResumeGame();
    }
    private void ProcessPlayButtonClick()
    {
        EnablePauseButton();
        gameCycle.StartGame();
    }
    private void ProcessPauseButtonClick()
    {
        EnableResumeButton();
        gameCycle.PauseGame();
    }

    void IStartGameListener.StartGame()
    {
        gameObject.SetActive(true);
    }

    void IFinishGameListener.FinishGame()
    {
        gameObject.SetActive(false);
    }
}
