using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void Play()
    {
        SceneSystem.LoadScene(SceneName.Level1);
        TimeManager.Run();
    }
}
