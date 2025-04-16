using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]

public class EnemyHealth : Health
{
    [SerializeField] private float _destroyDelay;
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
