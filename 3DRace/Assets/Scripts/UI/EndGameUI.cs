using System;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public event Action OnLevelRestart;
    public event Action OnQuitGame;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        finishPanel.SetActive(false);
        Subscribe();
    }

    private void Subscribe()
    {
        GameManager.Instance.OnGameStateChanged += Show;
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

    public void Show(GameState state)
    {
        if(state == GameState.Finished)
            finishPanel.SetActive(true);
    }
}