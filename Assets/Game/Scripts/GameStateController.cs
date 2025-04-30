using UnityEngine;

public class GameStateController : MonoBehaviour
{
    private readonly float _alphaWhenOn = 1f;

    [SerializeField] private PlayerHealth _player;
    [SerializeField] private CanvasGroup _looseScreen;
    [SerializeField] private CanvasGroup _winScreen;
    [SerializeField] private EnemyTracker _enemyTracker;

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
        _looseScreen.alpha = _alphaWhenOn;
        _looseScreen.interactable = true;
        _looseScreen.blocksRaycasts = true;
        TimeManager.Pause();
    }

    private void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _winScreen.alpha = _alphaWhenOn;
        _winScreen.interactable = true;
        _winScreen.blocksRaycasts = true;
        TimeManager.Pause();
    }
}
