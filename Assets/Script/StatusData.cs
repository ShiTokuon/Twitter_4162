
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]
public class StatusData : ScriptableObject
{
    public string NAME; //�L������
    public float MAXHP; //�ő�HP
    public float ATK; //�U����
    public int DEF; //�h���
    public float SPEED; //�ړ����x
    public float NockBack; //�̂�����
    public float SPAN; //�Ԋu
    public int EXP; //�o���l
    public bool Boss;//�{�X���G���G��
}