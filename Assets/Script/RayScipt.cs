using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScipt : MonoBehaviour
{
    private GameObject[] targets;
    private GameObject closeEnemy;
    [SerializeField] StatusData statusdata;
    Vector3 diff;

    void Start()
    {
        Search();//�ǂ̓G����ԋ߂������ׂ�

    }

    void Update()
    {
        if (closeEnemy != null)
        {//�G������������
            transform.position = Vector2.MoveTowards(transform.position, closeEnemy.transform.position, statusdata.SPEED * Time.deltaTime);
            diff = (closeEnemy.transform.position - this.transform.position).normalized;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.right, diff);

        }
        else
        {//�G�����Ȃ��ꍇ
            Destroy(gameObject);
        }
    }

    void Search()
    {
        float closeDist = 100;//���ɏ����l��100�ɂ���

        targets = GameObject.FindGameObjectsWithTag("Enemy");//Enemy�Ƃ���Tag����������
        foreach (GameObject t in targets)//�����������������[�v����
        {

            float tDist = Vector2.Distance(transform.position, t.transform.position);//�r�[���Ƃ��̓G�̋����𑪂�
            if (closeDist > tDist)//���݂̍ŒZ���������߂��ꍇ�Ɏ��s�����
            {
                closeDist = tDist;//�ŒZ�������X�V����
                closeEnemy = t;//�Q�[���I�u�W�F�N�g�ɂ��������
            }

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyScript>().Damage(statusdata.ATK);
            other.gameObject.GetComponent<EnemyScript>().NockBack(statusdata.NockBack);
            Destroy(gameObject);//�������g������
        }
    }
}