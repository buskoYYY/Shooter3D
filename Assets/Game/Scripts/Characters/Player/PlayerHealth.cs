using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] protected int _maxHealth;

    protected override void Start()
    {
        _maxValue = _maxHealth;
        base.Start();
    }
    protected override void OnDeath()
    {
        Time.timeScale = 0;
        base.OnDeath();
    }
}
