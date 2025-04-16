using System;
using UnityEngine;

public abstract class Changeble : MonoBehaviour
{
    public event Action<float, float> ValueChanged;

    protected void OnValueChanged(float currentValue, float maxValue)
    {
        ValueChanged?.Invoke(currentValue, maxValue);
    }
}
