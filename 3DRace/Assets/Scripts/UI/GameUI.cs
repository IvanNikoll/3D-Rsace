using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class controls UI of the level scene.
/// </summary>

public class GameUI : MonoBehaviour
{
    public event Action OnLevelRestart;
    public event Action OnQuitGame;
    [Header("Finish Panel")]
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [Header ("Start Panel")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TextMeshProUGUI roundText;
    [Header ("Countdown Panel")]
    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private TextMeshProUGUI countdownText;

    private void Start()
    {
        finishPanel.SetActive(false);
        Subscribe();
    }

    public void ShowPanel(GameState state)
    {
        switch (state)
        {
            case GameState.WaitingToStart:
                startPanel.SetActive(true);
                break;
            case GameState.Countdown:
                startPanel.SetActive(false);
                countdownPanel.SetActive(true);
                break;
            case GameState.Playing:
                countdownPanel?.SetActive(false);
                break;
            case GameState.Finished:
                finishPanel.SetActive(true);
                break;
            default: throw new ArgumentException(nameof(state));
               
        }
    }

    private void Subscribe()
    {
        GameManager.Instance.OnGameStateChanged += ShowPanel;
        restartButton.onClick.AddListener(() => RestartLevelPressed()); 
        quitButton.onClick.AddListener(() => QuitGamePressed());
    }

    private void RestartLevelPressed()
    {
        OnLevelRestart?.Invoke();
    }

    private void QuitGamePressed()
    {
        OnQuitGame?.Invoke();
    }

    public void SendText(UITextType textType, string text)
    {
        switch (textType) 
        {
            case UITextType.Round:
                roundText.SetText(text);
                break;
            case UITextType.Countdown:
                countdownText.SetText(text);
                break;
        }
    }

}