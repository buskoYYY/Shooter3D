using System;
using UnityEngine;

public class EnemyAnimationEventHandler : MonoBehaviour
{
    public event Action HitAnimationEnded;
    public event Action Attacked;
    public event Action AttackEnded;

    public void Hit()
    {
        HitAnimationEnded?.Invoke();
    }

    public void OnAttack()
    {
        Attacked?.Invoke();
    }

    public void OnAttackEnded()
    {
        AttackEnded?.Invoke();
    }
}
