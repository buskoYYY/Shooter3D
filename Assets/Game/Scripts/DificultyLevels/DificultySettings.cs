using UnityEngine;

[CreateAssetMenu(fileName = "DificutyLevel", menuName = "ScriptableObject")]
public class DificultySettings : ScriptableObject
{
    [SerializeField] private int _enemyHealth;
    [SerializeField] private float _enemySpeed;

    public int GetEnemyHealth()
    {
        return _enemyHealth;
    }

    public float GetEnemySpeed()
    {
        return _enemySpeed;
    }
}
