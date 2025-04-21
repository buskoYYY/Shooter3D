using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelWindow : MonoBehaviour
{
    [SerializeField] private LevelCell _cellPrefab;
    [SerializeField] private RectTransform _container;
    [SerializeField] private Button _backButton;
    private List<string> _sceneNames = new();
    private List<LevelCell> _levelCells = new();

    private void OnEnable()
    {
        _backButton.onClick.AddListener(Close);
        FillLevels();
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(Close);
        ClearLevels();
    }

    public void SetLevelsNames(List<string> sceneNames)
    {
        _sceneNames = sceneNames;
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void FillLevels()
    {
        LevelCell cell;
        int levelNumber = 1;

        foreach (string sceneName in _sceneNames)
        {
            cell = Instantiate(_cellPrefab, _container);
            cell.Initialize(sceneName, levelNumber, SaveService.IsUnlockedLevel(sceneName));
            cell.SceneSelected += OnSceneSelected;
            _levelCells.Add(cell);
            levelNumber++;
        }
    }

    private void ClearLevels()
    {
        foreach (LevelCell cell in _levelCells)
        {
            cell.SceneSelected -= OnSceneSelected;
            Destroy(cell.gameObject);
        }

        _levelCells.Clear();
    }

    private void OnSceneSelected(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
