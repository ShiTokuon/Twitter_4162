using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    GameObject Player;
    Vector3 PlayerPos;
    [SerializeField] StatusData statusdata;
    bool MUTEKI;
    private float HP;
    private float currentTime = 0f;
    Vector3 diff;
    Vector3 vector;
    private Rigidbody2D rb;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position;
        this.transform.LookAt(PlayerPos);
        HP = statusdata.MAXHP;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerPos = Player.transform.position;//�v���C���[�̌��݈ʒu���擾
        transform.position = Vector2.MoveTowards(transform.position,
            PlayerPos, statusdata.SPEED * Time.deltaTime);//���݈ʒu����v���C���[�̈ʒu�Ɍ����Ĉړ�
        diff.x = PlayerPos.x - this.transform.position.x;//�v���C���[�ƓG�L������X���̈ʒu�֌W���擾����
        if (diff.x > 0)
        {//Player���G�L�����̉E���ɂ��鎞�E��������
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        if (diff.x < 0)
        {//Player���G�L�����̍����ɂ��鎞����������
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }

        if (MUTEKI)//�U�����󂯂Ă���0.2�b��ɂ��鏈��
        {
            currentTime += Time.deltaTime;
            if (currentTime > statusdata.SPAN)
            {
                currentTime = 0f;
                MUTEKI = false;//���G��ԏI��点��
                rb.velocity = new Vector2(0, 0);//�m�b�N�o�b�N���Ƃ߂�   
            }

        }
        if (HP <= 0)//HP��0�ȉ��ɂȂ����������
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage(float damage)
    {
        if (!MUTEKI)
        {//���G��Ԃ���Ȃ��Ƃ��ɍU�����󂯂�
            HP -= damage;//HP����
            Debug.Log(HP);//���݂�HP��\��
            MUTEKI = true;//���G��Ԃɂ���
        }
    }
    public void NockBack(float nockback)
    {
        Vector2 thisPos = transform.position;
        float distination = thisPos.x - PlayerPos.x;//�U�����󂯂Ď��_�ł̓G�L�����ƃv���C���[�Ƃ̈ʒu�֌W   
        rb.velocity = new Vector2(distination * nockback, 0);//�����������ɔ��ł���
    }
}