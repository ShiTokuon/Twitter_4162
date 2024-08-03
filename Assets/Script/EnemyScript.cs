using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public static EnemyScript instance;
    GameObject Player;
    Vector3 PlayerPos;
    public StatusData statusdata;
    bool MUTEKI;
    public float HP;
    private float currentTime = 0f;
    Vector3 diff;
    Vector3 vector;
    private Rigidbody2D rb;

    [SerializeField] GameObject Hitmark;
    Vector3 Hitpos;

    public bool once = true;
    [SerializeField] GameObject punchefect;
    Vector3 punchpos;

    float LifetimeCount = 0f;
    [SerializeField] GameObject EXP_prefab;
    [SerializeField] float Lifetime;

    public bool clearbool;
    [SerializeField]
    GameObject confetti;
    [SerializeField]
    GameObject GameClear;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPos = Player.transform.position;
        this.transform.LookAt(PlayerPos);
        HP = statusdata.MAXHP;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerPos = Player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos, statusdata.SPEED * Time.deltaTime);
        diff.x = PlayerPos.x - this.transform.position.x;
        if (diff.x > 0)
        {
            vector = new Vector3(0, -180, 0);
            this.transform.eulerAngles = vector;
        }
        if (diff.x < 0)
        {
            vector = new Vector3(0, 0, 0);
            this.transform.eulerAngles = vector;
        }

        if (MUTEKI)
        {
            currentTime += Time.deltaTime;
            if (currentTime > statusdata.SPAN)
            {
                currentTime = 0f;
                MUTEKI = false;
                rb.velocity = new Vector2(0, 0);
                punchefect.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        if (HP <= 0 && statusdata.Boss == true && clearbool == false)
        {
            clearbool = true;
            GameClear = GameObject.Find("GameClearTxt");
            GameClear.GetComponent<Text>().enabled = true;
            var confe = Instantiate(confetti, this.transform.position, transform.rotation);

            StartCoroutine("GameClearfunc");
            for (int i = 0; i < 100; i++)
            {
                Instantiate(confetti, this.transform.position, transform.rotation);
            }
            Debug.Log("ゲームクリア");
            PlayerHP.instance.clear();
        }

        if (HP <= 0)
        {
            Player.gameObject.GetComponent<PlayerHP>().Heal(1);
            Hitpos = this.transform.position;
            Hitpos.z = -2f;
            Hitmark.transform.position = Hitpos;
            Hitmark.GetComponent<SpriteRenderer>().enabled = true;
            punchpos = this.transform.position;
            punchpos.z = -2f;
            punchefect.transform.position = punchpos;
            punchefect.GetComponent<SpriteRenderer>().enabled = true;

            LifetimeCount += Time.deltaTime;
            if (LifetimeCount > Lifetime)
            {
                for (int i = 0; statusdata.EXP > i; i++)
                {
                    var zerachin = Instantiate(EXP_prefab, transform.position, transform.rotation);
                }
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator GameClearfunc()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Hitmark.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
    }

    public void Damage(float damage)
    {
        if (!MUTEKI)
        {
            Hitpos = this.transform.position;
            Hitpos.z = -3f;
            Hitmark.transform.position = Hitpos;
            Hitmark.GetComponent<SpriteRenderer>().enabled = true;
            HP -= damage;
            Debug.Log(HP);
            MUTEKI = true;
        }
    }

    public void NockBack(float nockback)
    {
        Vector2 thisPos = transform.position;
        float distination = thisPos.x - PlayerPos.x;
        rb.velocity = new Vector2(distination * nockback, 0);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHP>().Damage(statusdata.ATK);
        }
    }
}
