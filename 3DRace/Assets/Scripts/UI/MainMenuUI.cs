using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    private const string LEVELSCENENAME = "Level";
    public void StartGame()
    {
        SceneLoader.LoadScene(LEVELSCENENAME);
    }
}