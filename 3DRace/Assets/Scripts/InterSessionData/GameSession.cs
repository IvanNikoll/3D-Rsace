using UnityEngine;

/// <summary>
/// Holds intersession information with the player path and number of round.
/// </summary>
public class GameSession : MonoBehaviour
{
    [SerializeField] private PathRecorder pathRecorder;
    public static GameSession Instance { get; private set; }
    public GhostPath GhostPath { get { return _ghostPath; } }
    public int Try { get { return _try; } }

    private GameUI _endGameUI;
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

    /// <summary>
    /// Bootstrap initiates UI and path recorder when the scene is reloaded.
    /// </summary>
    public void InitiateUI(GameUI endGameUI)
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

    public void SetSecondTry()
    {
        _try++;
    }

    public void ResetSession()
    {
        _try = 1;
        _ghostPath.Clear();
    }

    /// <summary>
    /// Sets 1st or the 2nd round at the end of each race.
    /// </summary>
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

}
