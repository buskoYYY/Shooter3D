using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1; 
    }

    public void Play()
    {
        SceneSystem.LoadScene(SceneName.Game);
        TimeManager.Run();
    }
}
