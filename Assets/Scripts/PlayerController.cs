using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private float _playerSpeed = 3.5f;
    [SerializeField] private Rigidbody2D _playerRb;
    private Camera _camera;

    private Vector2 _movement;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        HandleInput();
        FacePlayerToMouse();
    }

    private void HandleInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    private void FacePlayerToMouse()
    {
        var mouse = Input.mousePosition;
        var screenPoint = _camera.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle -90);
    }

    private void CalculateMovement()
    {
        _playerRb.MovePosition(_playerRb.position + _movement * _playerSpeed * Time.fixedDeltaTime);
        
    }
}