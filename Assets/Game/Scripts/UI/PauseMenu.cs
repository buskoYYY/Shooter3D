using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    private readonly float _alphaWhenOff = 0f;
    private readonly float _alphaWhenOn = 1f;
    private readonly float _timeWhenOn = 0f;
    private readonly float _timeWhenOff = 1f;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private InputReader _inputReader;

    private bool _isPaused = false;

    public bool IsPaused => _isPaused;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

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
        Time.timeScale = _timeWhenOff;
        _canvasGroup.alpha = _alphaWhenOff;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isPaused = false;
    }

    public void ExitToMenu()
    {
        SceneSystem.LoadScene(SceneName.MainMenu);
    }

    private void Pause()
    {
        Time.timeScale = _timeWhenOn;
        _canvasGroup.alpha = _alphaWhenOn;
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
