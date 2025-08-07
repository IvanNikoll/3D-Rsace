using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private EndGameUI _endGameUI;
    public static GameSession Instance { get; private set; }

    public int Try { get { return _try; } }
    
    [Range (1,2)]
    private int _try;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Instance = this;
        _try = 1;
    }

    public void InitiateUI(EndGameUI endGameUI)
    {
        _endGameUI = endGameUI;
        _endGameUI.OnLevelRestart += RestartLevel;
        _endGameUI.OnQuitGame += QuitGame;
    }

    private void RestartLevel()
    {
        if (_try == 1)
            SetSecondTry();
        if (_try == 2)
            ResetSession();
        SceneLoader.RestartScene();
    }

    private void QuitGame()
    {
        SceneLoader.QuitGame();
    }

    public void SetSecondTry()
    {
        _try++;
    }

    public void ResetSession()
    {
        _try = 1;
    }
}