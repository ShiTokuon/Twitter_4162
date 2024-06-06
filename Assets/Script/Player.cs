using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField,Header("ステータス")] 
    StatusData statusdata;

    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;
    Vector3 worldAngle; //角度を代入する
    public SpriteRenderer spriteRenderer;
    private float currentTime;
    [SerializeField] GameObject punch;
    [SerializeField] Sprite imageIdle;
    [SerializeField] Sprite imagePunch;


    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = imageIdle;//待機状態の画像
        punch.GetComponent<BoxCollider2D>().enabled = false;//Punchの当たり判定をなくす
    }

    void Update()
    {
        // 時間を更新
        currentTime += Time.deltaTime;

        // 2秒ごとに実行
        if (currentTime > statusdata.SPAN)
        {
            spriteRenderer.sprite = imagePunch; // Playerの画像を攻撃用の画像に切り替える
            punch.GetComponent<BoxCollider2D>().enabled = true; // あたり判定をつける
            StartCoroutine("Punchswitch"); // 攻撃を持続させるためのコルーチンを起動する
            currentTime = 0f;
        }

        _Move();
    }

    IEnumerator Punchswitch()
    {
        yield return new WaitForSeconds(5);//5秒後に下の2行を実行する
        spriteRenderer.sprite = imageIdle;//待機状態の画像に切り替える
        punch.GetComponent<BoxCollider2D>().enabled = false;//あたり判定をなくす
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
            worldAngle.y = 0f;//通常の向き
            this.transform.localEulerAngles = worldAngle;//自分の角度に代入する
            position.x -= statusdata.SPEED * Time.deltaTime;
        }
        else if (_inputVelocity.x > 0 && position.x < 3.2)
        {
            worldAngle.y = -180f;//右向きの角度
            this.transform.localEulerAngles = worldAngle;//自分の角度に代入
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
