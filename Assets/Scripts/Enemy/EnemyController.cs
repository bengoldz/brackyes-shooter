using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _enemyRb;
    [SerializeField] private Rigidbody2D _target;
    [SerializeField] private float _enemySpeed = 3f;
    [SerializeField] private GameObject _deathEffect;

    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth = 100;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        transform.LookAt(_target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, _target.position) > 0.1f)
        {
            transform.Translate(new Vector3(_enemySpeed * Time.deltaTime, 0, 0));
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"Beng :: enemy health {_health}");
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Instantiate(_deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        //add score
    }

    // private void FixedUpdate()
    // {
    //     Vector3 direction = (_target.transform.position - transform.position).normalized;
    //     _enemyRb.MovePosition(transform.position + direction * _enemySpeed * Time.deltaTime);
    //
    // }
    
}