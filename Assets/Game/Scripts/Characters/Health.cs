using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _value;

    public event Action<Health> Died;

    public float Value
    {
        private set
        {
            _value = Mathf.Clamp(value, 0, _maxValue);
        }
        get
        {
            return _value;
        }

    }

    private void Start()
    {
        _value = _maxValue;
    }

    public void TakeDamage(float amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Cant damage negative amount");
        }

        Value -= amount;

        if (Value == 0)
        {
            OnDeath();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Cant heal negative amount");
        }

        Value += amount;
    }

    protected virtual void OnDeath()
    {
        Died?.Invoke(this);
    }
}
