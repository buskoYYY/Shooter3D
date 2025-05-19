using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Changeble
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private float _timeToReloading;

    private Weapon _currentWeapon;
    private bool _canShoot = true;

    public event Action Shot;
    public event Action Reloaded;

    public bool CanShoot => _canShoot;

    private void OnEnable()
    {
        _inputReader.Shot += Shoot;
        _inputReader.WeaponSwitched += SwitchWeapon;
        _inputReader.Reloaded += Reload;
    }

    private void Start()
    {
        SwitchWeapon(1);
        OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);
    }

    private void OnDisable()
    {
        _inputReader.Shot -= Shoot;
        _inputReader.WeaponSwitched -= SwitchWeapon;
        _inputReader.Reloaded -= Reload;
    }

    private void Shoot()
    {
        OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);

        if (_currentWeapon.TryShot(_camera) && _canShoot == false)
        {
            Shot?.Invoke();
        }
    }

    private void Reload()
    {
        _canShoot = false;
        _currentWeapon.Reload();
        Reloaded?.Invoke();
        OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);
        StartCoroutine(ReloadDelay());
    }

    private void SwitchWeapon(int weaponNumber)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.gameObject.SetActive(false);
        }

        _currentWeapon = _weapons[weaponNumber - 1];
        _currentWeapon.gameObject.SetActive(true);
        OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_timeToReloading);
        _canShoot = true;
    }
}
