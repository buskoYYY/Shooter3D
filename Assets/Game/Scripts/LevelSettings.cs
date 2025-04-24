using UnityEngine;

[CreateAssetMenu(fileName = "DificutyLevel", menuName = "ScriptableObject")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int _playerHealth;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private float _enemySpeed;

    public int GetEnemyHealth()
    {
        return _enemyHealth;
    }

    public int GetPlayerHealth()
    {
        return _playerHealth;
    }

    public float GetEnemySpeed()
    {
        return _enemySpeed;
    }
}
