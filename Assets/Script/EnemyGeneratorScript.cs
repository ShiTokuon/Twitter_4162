using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;//��������p�̓G�L����Prefab��ǂݍ���
    [SerializeField]
    private GameObject EliteenemyPrefab;
    GameObject Player;
    Vector2 PlayerPos;//�L�����N�^�[�̈ʒu��������ϐ�
    private float currentTime = 0f;
    private float span = 3f;
    //�����������������߂闐���p�̕ϐ�
    int rndUD;
    int rndLR;//�i���E�j
    Vector2 enemyspwnPos;//���������ʒu

    //[SerializeField]
    //private GameObject enemychestPrefab;
    [SerializeField]
    private GameObject BossPrefab;

    bool Chest1;
    bool Chest2;
    bool Boss;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//Player�Ƃ����^�O���������A���������I�u�W�F�N�g��������
    }
    void Update()
    {
        currentTime += Time.deltaTime;//���Ԍo�߂�currentTime�ɑ�������Ԃ𑪂�

        if (Time.time < 90f)
        {
            if (currentTime > span)//span�Őݒ肵��3�b���z�����珈�������s
            {
                EnemyGenerate(EnemyPrefab);
                currentTime = 0f;
            }
            if (Time.time > 20 && Chest1 == false)
            {
                Chest1 = true;
                //EnemyGenerate(enemychestPrefab);
                currentTime = 0f;
            }
        }
        if (90f < Time.time && Time.time < 150f)
        {
            if (currentTime > span)//3�b����
            {
                // Debug.Log(span);
                EnemyGenerate(EnemyPrefab);
                EnemyGenerate(EliteenemyPrefab);
                currentTime = 0f;
            }
            if (Time.time > 120f && Chest2 == false)
            {
                Chest2 = true;
                //EnemyGenerate(enemychestPrefab);
                currentTime = 0f;
            }

            if (150f < Time.time && Boss == false)
            {
                Boss = true;
                EnemyGenerate(EnemyPrefab);
                EnemyGenerate(EliteenemyPrefab);
                EnemyGenerate(BossPrefab);
            }
        }
    }

    public void EnemyGenerate(GameObject Enemy)
    {
        //EnemyPrefab�̃X�|�[���ʒu�����߂�

        PlayerPos = Player.transform.position;//Player�̌��݈ʒu���擾

        //�㉺�ǂ���ɃX�|�[�����邩
        rndUD = Random.Range(0, 2);//0:�� 1:��
                                   //���E�ǂ���ɂȂ邩
        rndLR = Random.Range(0, 2);//0:�� 1:�E

        //�v���C���[����ǂꂭ�炢���ꂽ�ʒu�Ő������邩
        float rndPositiveX = Random.Range(1.0f, 3.0f);
        float rndPositiveY = Random.Range(1.0f, 3.0f);
        float rndNegativeX = Random.Range(-1.0f, -3.0f);
        float rndNegativeY = Random.Range(-1.0f, -3.0f);

        switch (rndUD)
        {
            case 0://rndUD����̏ꍇ
                enemyspwnPos.y = rndPositiveY;//������̗�������

                break;
            case 1://rndUD�����̏ꍇ
                enemyspwnPos.y = rndNegativeY;//�������̗�������
                break;
        }

        switch (rndLR)
        {
            case 0://rndLR�����̏ꍇ
                enemyspwnPos.x = rndPositiveX;//�������̗�������
                break;
            case 1://rndLR���E�̏ꍇ
                enemyspwnPos.x = rndNegativeX;//�E�����̗�������
                break;
        }

        enemyspwnPos = enemyspwnPos + PlayerPos;//�v���C���[�̈ʒu�ɐ�قǂ̗����𑫂����ʒu�ɐ�������
        var enemy = Instantiate(Enemy, enemyspwnPos, transform.rotation);//Prefab�𐶐�����
    }

}
