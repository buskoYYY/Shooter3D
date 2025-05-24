using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private TweenAniamation _tweenAniamation;

    private bool _isPaused = false;

    public bool IsPaused => _isPaused;

    private void OnEnable()
    {
        _inputReader.Paused += ChangeState;
    }

    private void OnDisable()
    {
        _inputReader.Paused -= ChangeState;
    }
    public void UnPause()
    {
        TimeManager.Run();
        _tweenAniamation.Hide(_canvasGroup);
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isPaused = false;
    }

    public void ExitToMenu()
    {
        SceneSystem.LoadScene(SceneName.MainMenu);
        TimeManager.Run();
    }

    private void Pause()
    {
        TimeManager.Pause();
        _tweenAniamation.Show(_canvasGroup);
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _isPaused = true;
    }

    private void ChangeState()
    {
        if (_isPaused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }
}
