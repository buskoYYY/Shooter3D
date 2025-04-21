using System.Collections.Generic;
using UnityEngine;

public static class SaveService
{
    private const string SAVE_TITLE = "Save";

    private static SaveData _saveData;
    private static List<string> _sceneNames = new();

    public static List<string> ComplitedLevels => _saveData.UnlockedLevels;

    public static void Initialize(List<string> sceneNames)
    {
        _sceneNames = sceneNames;
        _saveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(SAVE_TITLE)) ?? new SaveData();
    }

    public static void Save()
    {
        PlayerPrefs.SetString(SAVE_TITLE, JsonUtility.ToJson(_saveData));
    }

    public static void UnlockNetLevel(string currentSceneName)
    {
        int sceneIndex = _sceneNames.FindIndex(i => i == currentSceneName);

        if (sceneIndex == _sceneNames.Count - 1)
            return;

        string sceneName = _sceneNames[sceneIndex + 1];

        if (_saveData.UnlockedLevels.Contains(sceneName) == false)
            _saveData.UnlockedLevels.Add(sceneName);

        Save();
    }

    public static bool IsUnlockedLevel(string sceneName) => _saveData.UnlockedLevels.Contains(sceneName);
}
