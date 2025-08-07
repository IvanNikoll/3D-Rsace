using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
   [SerializeField] private EndGameUI endGameUI;
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
