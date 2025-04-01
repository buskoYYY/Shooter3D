using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;

    private void OnEnable()
    {
        _inputReader.Shot += Shoot;
        _inputReader.WeaponSwitched += SwitchWeapon;
        _inputReader.Reloaded += Reload;
    }

    private void Start()
    {
        SwitchWeapon(1);
    }

    private void OnDisable()
    {
        _inputReader.Shot -= Shoot;
        _inputReader.WeaponSwitched -= SwitchWeapon;
        _inputReader.Reloaded -= Reload;
    }

    private void Shoot()
    {
        _currentWeapon.Shot(_camera);
    }

    private void Reload()
    {
        _currentWeapon.Reload();
    }

    private void SwitchWeapon(int weaponNumber)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.gameObject.SetActive(false);
        }

        _currentWeapon = _weapons[weaponNumber - 1];
        _currentWeapon.gameObject.SetActive(true);
    }
}
