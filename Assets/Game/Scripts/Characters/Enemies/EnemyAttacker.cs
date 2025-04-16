using System;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private EnemyAnimationEventHandler _animationEvent;

    private bool _isAttacking = false;

    public event Action Attacking;

    private void OnEnable()
    {
        _animationEvent.Attacked += Attack;
        _animationEvent.AttackEnded += AllowAttacking;
        _animationEvent.HitAnimationEnded += AllowAttacking;
    }

    private void Update()
    {
        if(_isAttacking == false && IsPlayerNear())
        {
            StartAtacking();
        }
    }

    private void OnDisable()
    {
        _animationEvent.Attacked -= Attack;
        _animationEvent.AttackEnded -= AllowAttacking;
        _animationEvent.HitAnimationEnded -= AllowAttacking;
    }

    private void StartAtacking()
    {
        _isAttacking=true;
        Attacking?.Invoke();
    }

    private void Attack()
    {
        if (IsPlayerNear())
        {
            _player.TakeDamage(_damage);
        }
    }

    private void AllowAttacking()
    {
        _isAttacking = false;
    }

    private bool IsPlayerNear()
    {
        return Vector3.Distance(transform.position, _player.transform.position) <= _attackDistance;
    }
}
