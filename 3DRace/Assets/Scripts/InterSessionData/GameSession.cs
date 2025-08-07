using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private PathRecorder pathRecorder;
    private EndGameUI _endGameUI;
    public static GameSession Instance { get; private set; }
    public GhostPath GhostPath { get { return _ghostPath; } }
    public int Try { get { return _try; } }
    private GhostPath _ghostPath;
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
        GameManager.Instance.OnGameStateChanged += GameFinished;
    }

    public void InitializePathRecorder(PathRecorder PathRecorder)
    {
        pathRecorder = PathRecorder;
    }

    private void GameFinished(GameState state)
    {
        if (state == GameState.Finished)
        {
            if (_try <= 2)
            {
                _ghostPath = pathRecorder.ProvidePath();
                SetSecondTry();
            }
            if (_try > 2)
            {
                ResetSession();
            }
            Debug.Log("Try = " +  _try);
        }
    }

    private void RestartLevel()
    {
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
        _ghostPath.Clear();
    }
}