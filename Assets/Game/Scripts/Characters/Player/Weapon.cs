using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private readonly Vector2 _screenShotPercent = new Vector2(0.5f, 0.5f);

    [SerializeField] private WeaponName _weaponName;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private float _damage;
    [SerializeField] private int _maxMagazineCapacity;
    [SerializeField] private int _maxBulletsInInventory;
    [SerializeField] private GameObject _test;

    private int _bulletsInMagazine = 0;
    private int _bulletsInInventory = 0;

    public event Action Shot;
    public event Action Reloaded;

    public int BulletsInMagazine => _bulletsInMagazine;
    public int MaxMagazineCapacity => _maxMagazineCapacity;
    private void Start()
    {
        _bulletsInMagazine = _maxMagazineCapacity;
        _bulletsInInventory = _maxBulletsInInventory;
    }

    public bool TryShot(Camera camera)
    {
        if (_bulletsInMagazine > 0)
        {
            Ray ray = camera.ViewportPointToRay(_screenShotPercent);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out EnemyHealth enemy))
                {
                    enemy.TakeDamage(_damage);
                    ParticleSystem effect = Instantiate(_hitEffect, hit.point,Quaternion.identity);
                    effect.transform.forward = hit.normal;
                }
                Instantiate(_test, hit.point, Quaternion.identity);              
            }

            _bulletsInMagazine--;
            Shot?.Invoke();
            return true;
        }

        return false;
    }

    public void Reload()
    {
        int bulletsLoad = _maxMagazineCapacity - _bulletsInMagazine;

        if (bulletsLoad <= _bulletsInInventory)
        {
            _bulletsInInventory -= bulletsLoad;
        }
        else
        {
            bulletsLoad = _bulletsInInventory;
            _bulletsInInventory = 0;
        }

        _bulletsInMagazine += bulletsLoad;
        Reloaded?.Invoke();
    }
}

public enum WeaponName
{
    Carabine,
    ShortGun,
    Pistol
}
