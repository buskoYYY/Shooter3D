
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneSystem
{
    public static void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}

public enum SceneName
{
    MainMenu = 0,
    Game = 1
}
