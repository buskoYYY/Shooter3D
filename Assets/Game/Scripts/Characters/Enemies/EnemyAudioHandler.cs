using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioHandler : MonoBehaviour
{
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    [SerializeField] private float _ambientPlayDelay;
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _ambientSound;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private EnemyHealth _health;

    private Coroutine _playingAmbientSound;

    private void OnEnable()
    {
        _attacker.Attacking += PlayAttackSound;
        _health.TookDamage += PlayHitSound;

        if (_playingAmbientSound != null)
        {
            StopCoroutine(_playingAmbientSound);
        }

        _playingAmbientSound = StartCoroutine(PlayAmbientSound());
    }

    private void OnDisable()
    {
        _attacker.Attacking -= PlayAttackSound;
        _health.TookDamage -= PlayHitSound;
    }
    private IEnumerator PlayAmbientSound()
    {
        var wait = new WaitForSeconds(_ambientPlayDelay);

        while (enabled)
        {
            yield return wait;

            if (_source.isPlaying == false)
            {
                _source.clip = _ambientSound[Random.Range(0, _ambientSound.Count)];
                _source.pitch = Random.Range(_minPitch, _maxPitch);
                _source.Play();
            }
        }

        _playingAmbientSound = null;
    }

    private void PlayAttackSound()
    {
        _source.clip = _attackSound;
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.Play();
    }

    private void PlayHitSound()
    {
        _source.clip = _hitSound;
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.Play();
    }
}
