using UnityEngine;

public class LevelBootstrap : MonoBehaviour
{
   [SerializeField] private EndGameUI endGameUI;

    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        GameSession.Instance.InitiateUI(endGameUI);
    }
}
