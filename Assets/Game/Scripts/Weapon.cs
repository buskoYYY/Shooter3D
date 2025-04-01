using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private readonly Vector2 _screenShotPercent = new Vector2(0.5f, 0.5f);

    [SerializeField] private WeaponName _weaponName;
    [SerializeField] private float _damage;
    [SerializeField] private int _maxMagazineCapacity;
    [SerializeField] private int _maxBulletsInInventory;
    [SerializeField] private GameObject _test;

    private int _bulletsInMagazine = 0;
    private int _bulletsInInventory = 0;

    private void Start()
    {
        _bulletsInMagazine = _maxMagazineCapacity;
        _bulletsInInventory = _maxBulletsInInventory;
    }

    public void Shot(Camera camera)
    {
        if (_bulletsInMagazine > 0)
        {
            Ray ray = camera.ViewportPointToRay(_screenShotPercent);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Instantiate(_test, hit.point, Quaternion.identity);
            }

            _bulletsInMagazine--;
        }
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
    }
}

public enum WeaponName
{
    Carabine,
    ShortGun,
    Pistol
}
