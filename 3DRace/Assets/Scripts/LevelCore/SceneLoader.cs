using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class provides transition between scenes. 
/// </summary>

public static class SceneLoader
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void QuitGame()
    {
#if UNITY_WEBGL
        Time.timeScale = 0f;
#else
    Application.Quit();
#endif
    }
}