using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    [SerializeField] private List<EnemyHealth> _enemies;

    private int _enemyCount = 0;

    public event Action AllEnemiesDied;

    public int EnemyCount => _enemyCount;

    private void OnEnable()
    {
        foreach(EnemyHealth enemy in _enemies)
        {
            enemy.Spawned += OnEnemySpawn;
        }

        foreach (EnemyHealth enemy in _enemies)
        {
            enemy.Died += OnEnemyDieD;
        }
    }

    private void OnDisable()
    {
        foreach (EnemyHealth enemy in _enemies)
        {
            enemy.Spawned -= OnEnemySpawn;
        }

        foreach (EnemyHealth enemy in _enemies)
        {
            enemy.Died -= OnEnemyDieD;
        }
    }

    private void  OnEnemySpawn()
    {
        _enemyCount++;
    }

    private void OnEnemyDieD()
    {
        _enemyCount--;

        if(_enemyCount == 0)
        {
            AllEnemiesDied?.Invoke();
        }
    }
}
