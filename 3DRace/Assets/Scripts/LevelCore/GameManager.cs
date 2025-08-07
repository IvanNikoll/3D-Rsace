using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<GameState> OnGameStateChanged;
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    [SerializeField] private GhostPlayer ghostPlayer;
    [SerializeField] private CountdownTimer countdownTimer;
    [SerializeField] private FinishLine finishLine;
    [SerializeField] private EndGameUI endGameUI;
    [SerializeField] private GhostPlayerFactory ghostPlayerFactory;
    private bool _IsCountdownStarted = false;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        CheckRound();
        endGameUI.SendText(UITextType.Round, GameSession.Instance.Try.ToString());
        SetState(GameState.WaitingToStart);
        Subscribe();
    }

    private void CheckRound()
    {
        if (GameSession.Instance.Try == 1)
            return;
        if(GameSession.Instance.Try == 2)
            ghostPlayer = ghostPlayerFactory.GetGgostPlayer(GameSession.Instance.GhostPath);
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }

    public void EndGame()
    {
        SetState(GameState.Finished);
    }

    private void Subscribe()
    {
        countdownTimer.OnCountdownFinished += StartGame;
        finishLine.OnPlayerFinished += EndGame;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCountdown();
            _IsCountdownStarted = true;
        }
    }

    private void StartCountdown()
    {
        if (!_IsCountdownStarted)
        {
            SetState(GameState.Countdown);
            countdownTimer.StartCountdown();
        }
    }

    private void SetState(GameState newState)
    {
        CurrentState = newState;
        OnGameStateChanged?.Invoke(CurrentState);
        Debug.Log("Game State: " + newState);
    }
}