using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1; 
    }

    public void Play()
    {
        SceneSystem.LoadScene(SceneName.Level1);
        TimeManager.Run();
    }
}
