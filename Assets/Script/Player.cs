using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField,Header("�X�e�[�^�X")] 
    StatusData statusdata;

    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;
    Vector3 worldAngle; //�p�x��������

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
            worldAngle.y = 0f;//�ʏ�̌���
            this.transform.localEulerAngles = worldAngle;//�����̊p�x�ɑ������
            position.x -= statusdata.SPEED * Time.deltaTime;
        }
        else if (_inputVelocity.x > 0 && position.x < 2.5)
        {
            worldAngle.y = -180f;//�E�����̊p�x
            this.transform.localEulerAngles = worldAngle;//�����̊p�x�ɑ��
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
