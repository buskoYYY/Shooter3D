using UnityEngine;
using UnityEngine.UI;

public class BarDisplay : MonoBehaviour
{
    [SerializeField] private Changeble _carier;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _carier.ValueChanged += UpdateVlues;
    }

    private void OnDisable()
    {
        _carier.ValueChanged += UpdateVlues;
    }

    private void UpdateVlues(float cureentValue, float maxValue)
    {
        _slider.value = cureentValue / maxValue;
    }
}
