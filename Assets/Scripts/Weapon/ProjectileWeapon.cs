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
                CreateBullet(-45f);
                CreateBullet( 0);
                CreateBullet( 45f);
            }
            else
            {
                CreateBullet(0);
            }
        }

        private void CreateBullet(float angle)
        {
            GameObject newBullet = Object.Instantiate(_bullet, _firePoint.position, Quaternion.identity);
            Bullet bullet = newBullet.GetComponent<Bullet>();
            
            Vector3 offset = Quaternion.Euler(0, 0, angle) * _firePoint.up;

            bullet.BulletRigidbody2D.AddForce(offset * _fireForce, ForceMode2D.Impulse);
            bullet.Initialize(_weaponDamage);

        }
    }
}