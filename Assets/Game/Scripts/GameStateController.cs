using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private CanvasGroup _looseScreen;
    [SerializeField] private CanvasGroup _winScreen;
    [SerializeField] private EnemyTracker _enemyTracker;
    [SerializeField] private TweenAniamation _tweenAniamation;

    private void OnEnable()
    {
        _player.Died += Lose;
        _enemyTracker.AllEnemiesDied += Win;
    }

    private void OnDisable()
    {
        _player.Died -= Lose;
        _enemyTracker.AllEnemiesDied -= Win;
    }

    public void Restart()
    {
        SceneSystem.RestartScene();
        TimeManager.Run();
    }

    public void ExitToMenu()
    {
        SceneSystem.LoadScene(SceneName.MainMenu);
        TimeManager.Run();
    }

    private void Lose()
    {
        StartProcess(_looseScreen);
    }

    private void Win()
    {
        StartProcess(_winScreen);
    }

    private void StartProcess(CanvasGroup canvasGroup)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        _tweenAniamation.Show(canvasGroup);
        TimeManager.Pause();
    }
}
