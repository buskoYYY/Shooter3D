using UnityEngine;
using UnityEngine.UI;

public class DificultyLevels : MonoBehaviour
{
    [SerializeField] private SaveData _saveData;
    [SerializeField] private DificultySettings _easyDifficulty;
    [SerializeField] private DificultySettings _mediumDifficulty;
    [SerializeField] private DificultySettings _hardDifficulty;
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _mediumButton;
    [SerializeField] private Button _hardButton;
    [SerializeField] private SceneLoader _sceneLoader;

    private int _enemyHealth;
    private float _enemySpeed;

    private void Start()
    {
        _easyButton.onClick.AddListener(() => SelectDifficulty(_easyDifficulty));
        _mediumButton.onClick.AddListener(() => SelectDifficulty(_mediumDifficulty));
        _hardButton.onClick.AddListener(() => SelectDifficulty(_hardDifficulty));
    }

    private void SelectDifficulty(DificultySettings difficulty)
    {
        _sceneLoader.Play();
        _enemyHealth = difficulty.GetEnemyHealth();
        _enemySpeed = difficulty.GetEnemySpeed();
        SaveSettings(_enemyHealth, _enemySpeed);
    }

    private void SaveSettings(int enemyHealth, float enemySpeed)
    {
        _saveData.SaveEnemyHealth(enemyHealth);
        _saveData.SaveEnemySpeed(enemySpeed);
    }
}
