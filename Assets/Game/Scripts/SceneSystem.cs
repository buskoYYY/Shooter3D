using UnityEngine.SceneManagement;

public static class SceneSystem
{
    public static void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

public enum SceneName
{
    MainMenu = 0,
    Game = 1
}
