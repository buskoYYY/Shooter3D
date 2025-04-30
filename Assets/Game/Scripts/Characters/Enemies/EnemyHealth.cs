using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class EnemyHealth : Health
{
    [SerializeField] private float _destroyDelay;
    [SerializeField] private SaveData _saveData;

    private int _health;

    public event Action Spawned;

    private void Awake()
    {
        if (_saveData != null)
        {
            _health = _saveData.GetEnemyHealth();
        }
    }
    private void OnEnable()
    {
        Spawned?.Invoke();
    }

    protected override void Start()
    {
        _maxValue = _health;
        base.Start();
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        List<MonoBehaviour> monobehs = GetComponents<MonoBehaviour>().ToList();

        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        foreach (var item in monobehs)
        {
            item.enabled = false;
        }

        Destroy(gameObject, _destroyDelay);
    }
}
