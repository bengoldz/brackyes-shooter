using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Weapon;

public class WeaponController : MonoBehaviour
{
    
    [SerializeField] private Transform _firePoint;
    [SerializeField] private WeaponData _currentWeaponData;
    
    private ProjectileWeapon _currentWeapon;
    private float _fireRate;
    private float _nextTimeToFire;

    private void Awake()
    {
        _currentWeapon =
            new ProjectileWeapon(_currentWeaponData._bullet, _currentWeaponData._fireRate, _firePoint, _currentWeaponData.FireForce, _currentWeaponData.Damage, _currentWeaponData.IsMultiShot);
    }

    private void Start()
    {
        _nextTimeToFire = _currentWeapon.FireRate;
    }


    private void Update()
    {
        _nextTimeToFire += Time.deltaTime;
        if (Input.GetButton("Fire1") && _nextTimeToFire >= _currentWeapon.FireRate)
        {
            _currentWeapon.Shoot();
            _nextTimeToFire = 0;
        }
    }
}
