using System;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed = 20;
        public Rigidbody2D bullet;

        private int _damage;


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
