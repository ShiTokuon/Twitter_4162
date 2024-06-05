using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{

    GameObject Player;
    Vector3 PlayerPos;

    private float speed = 0.5f;

    Vector3 diff;
    Vector3 vector;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position;
        this.transform.LookAt(PlayerPos);

    }
    void Update()
    {
        PlayerPos = Player.transform.position;//�v���C���[�̌��݈ʒu���擾
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, speed * Time.deltaTime);//���݈ʒu����v���C���[�̈ʒu�Ɍ����Ĉړ�
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
    }

}