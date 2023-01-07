using System;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D BulletRigidbody2D => _bulletRB;
        public float bulletSpeed = 20;
        [SerializeField] private Rigidbody2D _bulletRB;

        private int _damage;

        public void OnObjectSpawn(float angle, int fireForce, Transform firePoint)
        {
            Vector3 offset = Quaternion.Euler(0, 0, angle) * firePoint.up;
            _bulletRB.AddForce(offset * fireForce, ForceMode2D.Impulse);
        }

        public void Initialize(int damage)
        {
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(out EnemyController enemyComponent)) return;
            enemyComponent.TakeDamage(_damage);
            Destroy(gameObject);

        }
        
    }
}
