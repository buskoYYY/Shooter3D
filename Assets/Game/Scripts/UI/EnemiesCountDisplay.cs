using TMPro;
using UnityEngine;

public class EnemiesCountDisplay : MonoBehaviour
{
    [SerializeField] private EnemyTracker _enemyTracker;
    [SerializeField] private TextMeshProUGUI _enemiesCount;

    private void Update()
    {
        _enemiesCount.text = _enemyTracker.EnemyCount.ToString();
    }
}
