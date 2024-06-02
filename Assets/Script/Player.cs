using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Header("移動速度")]//Unity上で移動速度の値を変更出来るようにする
    private float _speed;

    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;

    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        _rigid.velocity = _inputVelocity * _speed;
    }

    public void Onmove(InputAction.CallbackContext context)
    {
        _inputVelocity = context.ReadValue<Vector2>();
    }
}
