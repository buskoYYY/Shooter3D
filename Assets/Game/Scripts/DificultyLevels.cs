using UnityEngine;
using UnityEngine.UI;

public class DificultyLevels : MonoBehaviour
{
    [SerializeField] private LevelSettings easyDifficulty;
    [SerializeField] private LevelSettings mediumDifficulty;
    [SerializeField] private LevelSettings hardDifficulty;
    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private SceneLoader _sceneLoader;

    private LevelSettings currentDifficulty;

    private void Start()
    {
        easyButton.onClick.AddListener(() => SelectDifficulty(easyDifficulty));
        mediumButton.onClick.AddListener(() => SelectDifficulty(mediumDifficulty));
        hardButton.onClick.AddListener(() => SelectDifficulty(hardDifficulty));
    }

    private void SelectDifficulty(LevelSettings difficulty)
    {
        currentDifficulty = difficulty;
        _sceneLoader.Play();
/*        levelSettingsInstaller.Instance.SetEnemyHealth(currentDifficulty.GetEnemyHealth());
        levelSettingsInstaller.Instance.SetPlayerHealth(currentDifficulty.GetPlayerHealth());
        levelSettingsInstaller.Instance.SetEnemySpeed(currentDifficulty.GetEnemySpeed());*/
    }
}
