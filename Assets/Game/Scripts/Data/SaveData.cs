using UnityEngine;
using YG;

public class SaveData: MonoBehaviour
{
    public const string SAVE_ENEMY_HEALTH = "SaveEnemyHealth";
    public const string SAVE_ENEMY_SPEED = "SaveEnemySpeed";

    public void SaveEnemyHealth(int health)
    {
        PlayerPrefs.SetInt(SAVE_ENEMY_HEALTH, health);
        YandexGame.savesData.Health = health;
        YandexGame.SaveProgress();
    }

    public void SaveEnemySpeed(float speed)
    {
        PlayerPrefs.SetFloat(SAVE_ENEMY_SPEED, speed);
        YandexGame.savesData.Speed = speed;
        YandexGame.SaveProgress();
    }

    public int GetEnemyHealth()
    {
        return PlayerPrefs.GetInt(SAVE_ENEMY_HEALTH);
    }

    public float GetEnemySpeed()
    {
        return PlayerPrefs.GetFloat(SAVE_ENEMY_SPEED);
    }
}
