using System;
using UnityEngine;

public abstract class Health : Changeble
{
    protected  float _maxValue;

    private float _value;

    public event Action Died;
    public event Action TookDamage;

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

    protected virtual void Start()
    {
        _value = _maxValue;
        OnValueChanged(Value, _maxValue);
    }

    public void TakeDamage(float amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Cant damage negative amount");
        }

        Value -= amount;
        TookDamage?.Invoke();
        OnValueChanged(Value, _maxValue);

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
        OnValueChanged(Value, _maxValue);
    }

    protected virtual void OnDeath()
    {
        Died?.Invoke();
    }
}
