using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnGameStateChanged;
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    [SerializeField] private CountdownTimer countdownTimer;
    [SerializeField] private FinishLine finishLine;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        SetState(GameState.Countdown);
        countdownTimer.OnCountdownFinished += StartGame;
        finishLine.OnPlayerFinished += EndGame;
        countdownTimer.StartCountdown();
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }

    public void EndGame()
    {
        SetState(GameState.Finished);
    }

    private void SetState(GameState newState)
    {
        CurrentState = newState;
        OnGameStateChanged?.Invoke(CurrentState);
        Debug.Log("Game State: " + newState);
    }
}