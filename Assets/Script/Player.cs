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
    Vector3 worldAngle; //角度を代入する

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
        Vector3 position = transform.position;

        if (_inputVelocity.y > 0 && position.y < 4.5)
        {
            position.y += _speed * Time.deltaTime;
        }
        else if (_inputVelocity.y < 0 && position.y > -4.5)
        {
            position.y -= _speed * Time.deltaTime;
        }
        else
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 0);
        }

        if (_inputVelocity.x < 0 && position.x > -2.5)
        {
            worldAngle.y = 0f;//通常の向き
            this.transform.localEulerAngles = worldAngle;//自分の角度に代入する
            position.x -= _speed * Time.deltaTime;
        }
        else if (_inputVelocity.x > 0 && position.x < 2.5)
        {
            worldAngle.y = -180f;//右向きの角度
            this.transform.localEulerAngles = worldAngle;//自分の角度に代入
            position.x += _speed * Time.deltaTime;
        }
        else
        {
            _rigid.velocity = new Vector2(0, _rigid.velocity.y);
        }

        transform.position = position;
    }


    public void Onmove(InputAction.CallbackContext context)
    {
        _inputVelocity = context.ReadValue<Vector2>();
    }
}
