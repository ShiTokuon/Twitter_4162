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

    [SerializeField] GameObject Hitmark;//☑
    Vector3 Hitpos;//☑

    public bool once = true;
    [SerializeField] GameObject punchefect;
    Vector3 punchpos;

    float LifetimeCount = 0f;
    [SerializeField] GameObject EXP_prefab;
    [SerializeField] float Lifetime;


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
        PlayerPos = Player.transform.position;//プレイヤーの現在位置を取得
        transform.position = Vector2.MoveTowards(transform.position,
            PlayerPos, statusdata.SPEED * Time.deltaTime);//現在位置からプレイヤーの位置に向けて移動
        diff.x = PlayerPos.x - this.transform.position.x;//プレイヤーと敵キャラのX軸の位置関係を取得する
        if (diff.x > 0)
        {//Playerが敵キャラの右側にいる時右側を向く
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        if (diff.x < 0)
        {//Playerが敵キャラの左側にいる時左側を向く
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }

        if (MUTEKI)//攻撃を受けてから0.2秒後にする処理
        {
            currentTime += Time.deltaTime;
            if (currentTime > statusdata.SPAN)
            {
                currentTime = 0f;
                MUTEKI = false;//無敵状態終わらせる
                rb.velocity = new Vector2(0, 0);//ノックバックをとめる 
                punchefect.GetComponent<SpriteRenderer>().enabled = false; //ヒットマーク画像を非表示に戻す
            }

        }

        if (HP <= 0)//HPが0以下になったら消える
        {
            Hitpos = this.transform.position;
            Hitpos.z = -2f;
            Hitmark.transform.position = Hitpos;
            Hitmark.GetComponent<SpriteRenderer>().enabled = true;
            LifetimeCount += Time.deltaTime;
            if (LifetimeCount > Lifetime)
            {
                for (int i = 0; statusdata.EXP > i; i++)
                {
                    var exp = Instantiate(EXP_prefab, transform.position, transform.rotation);
                }
                Destroy(this.gameObject);
            }

        }
    }
    public void Damage(float damage)
    {
        if (!MUTEKI)
        {//無敵状態じゃないときに攻撃を受ける
            Hitpos = this.transform.position;
            Hitpos.z = -3f;//Z軸を敵キャラよりも手前に設定
            Hitmark.transform.position = Hitpos;//ヒットマークの画像位置を移動させる
            Hitmark.GetComponent<SpriteRenderer>().enabled = true; //ヒットマーク画像を表示する☑
            HP -= damage;//HP減少
            Debug.Log(HP);//現在のHPを表示
            MUTEKI = true;//無敵状態にする
        }
    }
    public void NockBack(float nockback)
    {
        Vector2 thisPos = transform.position;
        float distination = thisPos.x - PlayerPos.x;//攻撃を受けて時点での敵キャラとプレイヤーとの位置関係   
        rb.velocity = new Vector2(distination * nockback, 0);//殴った方向に飛んでいく
    }
}
