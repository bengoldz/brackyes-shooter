using UnityEngine;

namespace Weapon
{
    public class ProjectileWeapon : IWeapon
    {
        public float FireRate => _fireRate;
        private float _fireRate;
        private int _fireForce = 20;
        private int _weaponDamage;
        private bool _isMultiShot;
        private GameObject _bullet;
        private Transform _firePoint;
        private Camera _camera;

        public ProjectileWeapon(GameObject bullet, float fireRate, Transform firePoint, int fireForce, int weaponDamage,
            bool isMultiShot)
        {
            _bullet = bullet;
            _fireRate = fireRate;
            _firePoint = firePoint;
            _fireForce = fireForce;
            _weaponDamage = weaponDamage;
            _isMultiShot = isMultiShot;
        }

        public void Shoot()
        {
            if (_isMultiShot)
            {
                CreateBullet(new Vector3(-0.5f, 0f, 0f));
                CreateBullet(new Vector3(0f, 0f, 0f));
                CreateBullet(new Vector3(0.5f, 0f, 0f));
            }
            else
            {
                CreateBullet(new Vector3(0, 0, 0));
            }
        }

        private void CreateBullet(Vector3 offsetRotation)
        {
            GameObject bullet = Object.Instantiate(_bullet, _firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector3 offset = _firePoint.up + offsetRotation;
            rb.AddForce(offset * _fireForce, ForceMode2D.Impulse);
            Bullet bulletGameObject = bullet.GetComponent<Bullet>();
            bulletGameObject.Initialize(_weaponDamage);
            
        }
    }
}