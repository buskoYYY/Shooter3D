using UnityEngine;

public class SaveData: MonoBehaviour
{
    private const string SAVE_ENEMY_HEALTH = "SaveEnemyHealth";
    private const string SAVE_ENEMY_SPEED = "SaveEnemySpeed";

    public void SaveEnemyHealth(int health)
    {
        PlayerPrefs.SetInt(SAVE_ENEMY_HEALTH, health);
    }

    public void SaveEnemySpeed(float speed)
    {
        PlayerPrefs.SetFloat(SAVE_ENEMY_SPEED, speed);
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
