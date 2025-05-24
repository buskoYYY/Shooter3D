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

    private void Lose()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _tweenAniamation.Show(_looseScreen);
        TimeManager.Pause();
    }

    private void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _tweenAniamation.Show(_winScreen);
        TimeManager.Pause();
    }
}
