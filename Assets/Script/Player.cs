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
    public SpriteRenderer spriteRenderer;
    private float currentTime;
    [SerializeField] GameObject punch;
    [SerializeField] Sprite imageIdle;
    [SerializeField] Sprite imagePunch;


    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = imageIdle;//�ҋ@��Ԃ̉摜
        punch.GetComponent<BoxCollider2D>().enabled = false;//Punch�̓����蔻����Ȃ���
    }

    void Update()
    {
        // ���Ԃ��X�V
        currentTime += Time.deltaTime;

        // 2�b���ƂɎ��s
        if (currentTime > statusdata.SPAN)
        {
            spriteRenderer.sprite = imagePunch; // Player�̉摜���U���p�̉摜�ɐ؂�ւ���
            punch.GetComponent<BoxCollider2D>().enabled = true; // �����蔻�������
            StartCoroutine("Punchswitch"); // �U�������������邽�߂̃R���[�`�����N������
            currentTime = 0f;
        }

        _Move();
    }

    IEnumerator Punchswitch()
    {
        yield return new WaitForSeconds(5);//5�b��ɉ���2�s�����s����
        spriteRenderer.sprite = imageIdle;//�ҋ@��Ԃ̉摜�ɐ؂�ւ���
        punch.GetComponent<BoxCollider2D>().enabled = false;//�����蔻����Ȃ���
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

        if (_inputVelocity.x < 0 && position.x > -3.2)
        {
            worldAngle.y = 0f;//�ʏ�̌���
            this.transform.localEulerAngles = worldAngle;//�����̊p�x�ɑ������
            position.x -= statusdata.SPEED * Time.deltaTime;
        }
        else if (_inputVelocity.x > 0 && position.x < 3.2)
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
