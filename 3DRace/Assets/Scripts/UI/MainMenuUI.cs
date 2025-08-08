using UnityEngine;

/// <summary>
/// This class controls UI of the main scene.
/// </summary>

public class MainMenuUI : MonoBehaviour
{
    private const string LEVELSCENENAME = "Level";

    public void StartGame()
    {
        SceneLoader.LoadScene(LEVELSCENENAME);
    }
}