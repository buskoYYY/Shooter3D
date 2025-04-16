using UnityEngine;
using UnityEngine.Playables;

public class EnemyAnimator : MonoBehaviour
{
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int Attack = Animator.StringToHash(nameof(Attack));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));

    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyAttacker _attacker;

    private void OnEnable()
    {
        _attacker.Attacking += PlayAttackAnimation;
        _health.TookDamage += PlayHitAnimation;
        _health.Died += PlayDeathAnimation;
    }

    private void OnDisable()
    {
        _attacker.Attacking -= PlayAttackAnimation;
        _health.TookDamage -= PlayHitAnimation;
        _health.Died -= PlayDeathAnimation;
    }

    private void PlayDeathAnimation()
    {
        _animator.SetTrigger(Die);
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger(Hit);
    }

    private void PlayAttackAnimation()
    {
        _animator.SetTrigger(Attack);
    }
}
