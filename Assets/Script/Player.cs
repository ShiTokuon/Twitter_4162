using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField,Header("ステータス")] 
    StatusData statusdata;

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
            position.y += statusdata.SPEED * Time.deltaTime;
        }
        else if (_inputVelocity.y < 0 && position.y > -4.5)
        {
            position.y -= statusdata.SPEED * Time.deltaTime;
        }
        else
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 0);
        }

        if (_inputVelocity.x < 0 && position.x > -2.5)
        {
            worldAngle.y = 0f;//通常の向き
            this.transform.localEulerAngles = worldAngle;//自分の角度に代入する
            position.x -= statusdata.SPEED * Time.deltaTime;
        }
        else if (_inputVelocity.x > 0 && position.x < 2.5)
        {
            worldAngle.y = -180f;//右向きの角度
            this.transform.localEulerAngles = worldAngle;//自分の角度に代入
            position.x += statusdata.SPEED * Time.deltaTime;
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
