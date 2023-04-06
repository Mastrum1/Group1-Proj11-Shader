using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class MoveGameObject : MonoBehaviour
{
    private Vector3 _input;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;

    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator = GetComponent<Animator>();
        InputManager();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputManager()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            _animator.SetBool("IsMoving", true);
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
}