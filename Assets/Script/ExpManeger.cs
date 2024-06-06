
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExpManeger : MonoBehaviour
{
    public static ExpManeger instance;
    [SerializeField] GameObject LevelUPpanelUI;
    [SerializeField] Text LevelText;
    //[SerializeField] Text ItemName;
    [SerializeField] Transform PlayerTrans;
    [SerializeField] GameObject Particle;
    [SerializeField] Text LevelUPText;
    //public GamemanegerScript GMscript;
    int Exp;
    AudioSource audioSource;
    public AudioClip getsound;
    public static int currentExp;
    public static int CurrentLv;
    int NextLevel;
    int NeedEXP;
    int CumEXP;//�݌v�o���l
    public int[,] EXP =//���x���ƕK�v�o���l
        { { 1, 0},
        {2, 6},
        {3, 8},
        {4, 10},
        {5, 14},
        {6, 18},
        {7, 20},
        {8, 25},
        {9, 30} ,
        {10, 35},
        {11, 40},
        {12, 50},
        {13, 60},
        {14, 70},
        {14, 80},

    };
    //Vector2 PlayerPos;


    public Slider EXPBar;
    public AudioClip sound;
    // Start is called before the first frame update

    void Start()
    {
        currentExp = 0;
        CurrentLv = 1;
        NextLevel = CurrentLv + 1;
        NeedEXP = EXP[CurrentLv, 1]; 
        if (instance == null)
        {
            instance = this;
        }
        if (EXPBar != null)
        {
            EXPBar.maxValue = NeedEXP;
            EXPBar.value = currentExp;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= EXP[CurrentLv, 1])
        {
            Debug.Log("���x���A�b�v" + CurrentLv + "��" + NextLevel);
            CurrentLv += 1;
            NextLevel += 1;
            NeedEXP = EXP[CurrentLv, 1]; // �C��
            LevelText.text = "Level:" + CurrentLv.ToString();
            StartCoroutine(LevelUP());
        }
    }

    private IEnumerator LevelUP()
    {
        audioSource.PlayOneShot(sound);
        Vector3 position = transform.position;
        currentExp = 0;
        EXPBar.maxValue = NeedEXP; // �C��
        EXPBar.value = currentExp;
        var confetti = Instantiate(Particle, position, transform.rotation);
        LevelUPText.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(2);
        LevelUPText.GetComponent<Text>().enabled = false;
    }

    public void ExpBarDraw()
    {//�o���l���E��������EXPorb����Ăяo�����

        CumEXP++;
        currentExp++;
        EXPBar.value = currentExp;
    }
}