
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;//UI���g�p����ۂ͐錾���K�v

public class PlayerHP : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    public Slider hpBar;
    float HP;
    bool MUTEKI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject Player;
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (hpBar != null)
        {
            hpBar.maxValue = statusdata.MAXHP;
            hpBar.value = statusdata.MAXHP;
        }
        HP = statusdata.MAXHP;
    }

    void Update()
    {
        hpBar.maxValue = statusdata.MAXHP;

        if (MUTEKI)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 0.2f)
            {
                // Debug.Log("���͖��G�ł�");
                currentTime = 0f;
                MUTEKI = false;
            }

        }
    }

    public void Damage(float damage)
    {
        if (!MUTEKI)
        {
            HP -= damage;
            MUTEKI = true;//���G��Ԃɂ���
            Debug.Log(HP);
            if (hpBar != null)
            {
                hpBar.value = HP;
            }
            if (HP < 0)
            {
                Player.GetComponent<SpriteRenderer>().enabled = false;
                GameOverUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Heal(int heal)
    {

        Debug.Log(HP);
        if (hpBar != null)
        {
            if (statusdata.MAXHP >= HP)
            {
                HP += heal;
            }
            if (statusdata.MAXHP <= HP)
            {

            }
        }
        hpBar.value = HP;
    }

}