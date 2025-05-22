using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerDamageEffect : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcess;
    [SerializeField] PlayerHealth _player;
    [SerializeField] private float _intensity;
    [SerializeField] private float _intensityReductionLevel;
    [SerializeField] private float _maxIntensityGap;
    [SerializeField] private float _transitionDelay;

    private Vignette _vignette;
    private float _startIntensity;

    private void OnEnable()
    {
        _player.TookDamage += StartDamageEffet;
    }

    private void Start()
    {
        _startIntensity = _intensity;

        _postProcess.profile.TryGetSettings(out _vignette);

        if (_vignette != null)
        {
            Debug.Log("Vinniete");
            _vignette.enabled.Override(false);
        }
    }

    private void OnDisable()
    {
        _player.TookDamage += StartDamageEffet;
    }

    private void StartDamageEffet()
    {
        StartCoroutine(TakeDamageEffect());
    }

    private IEnumerator TakeDamageEffect()
    {
        _intensity = _startIntensity; 

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(_intensity);

        yield return new WaitForSeconds(_maxIntensityGap);

        while (_intensity > 0)
        {
            _intensity -= _intensityReductionLevel;

            if (_intensity < 0)
            {
                _intensity = 0;
            }

            _vignette.intensity.Override(_intensity);

            yield return new WaitForSeconds(_transitionDelay);
        }

        _vignette.enabled.Override(false);
        yield break;
    }
}
