using System;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Changeble
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;

    public event Action Shot;
    public event Action Reloaded;

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
        if (PauseMenu.Instance.IsPaused == false)
        {
            if (_currentWeapon.TryShot(_camera))
            {
                Shot?.Invoke();
                OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);
            }
        }
    }

    private void Reload()
    {
        if (PauseMenu.Instance.IsPaused == false)
        {
            _currentWeapon.Reload();
            Reloaded?.Invoke();
            OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);
        }
    }

    private void SwitchWeapon(int weaponNumber)
    {
        if(PauseMenu.Instance.IsPaused == false)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.gameObject.SetActive(false);
            }

            _currentWeapon = _weapons[weaponNumber - 1];
            _currentWeapon.gameObject.SetActive(true);
            OnValueChanged(_currentWeapon.BulletsInMagazine, _currentWeapon.MaxMagazineCapacity);
        }
    }
}
