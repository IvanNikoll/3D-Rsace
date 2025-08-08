using UnityEngine;

/// <summary>
///This class is used to initialize player and UI a the start of the round  
/// </summary>

public class LevelBootstrap : MonoBehaviour
{
   [SerializeField] private GameUI endGameUI;
   [SerializeField] private PathRecorder player;

    private void Start()
    {
        InitializeUI();
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        GameSession.Instance.InitializePathRecorder(player);
    }

    private void InitializeUI()
    {
        GameSession.Instance.InitiateUI(endGameUI);
    }
}
