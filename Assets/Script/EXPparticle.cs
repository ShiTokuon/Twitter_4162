using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EXPparticle : MonoBehaviour
{
    Vector2 DestinationPos;
    Vector2 currentPos;
    Vector3 localAngle;
    Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        float rndPosX = Random.Range(-2.6f, 2.61f);//画面の横の長さ
        float rndPosY = Random.Range(-4.5f, 4.51f);//画面の縦の長さ
        currentPos.x = rndPosX;//ランダム値を代入する
        currentPos.y = 6f;//Y軸を表示範囲よりも上に設定しておく
        transform.position = currentPos;//現在位置を変える
        DestinationPos = transform.position;//目的値のX軸を代入
        DestinationPos.y = rndPosY;//目的値のY軸を代入
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, DestinationPos, 4 * Time.deltaTime);
        currentPos = transform.position;
        if (currentPos.y == DestinationPos.y)
        {
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExpManeger.instance.ExpBarDraw();
            Destroy(this.gameObject);
        }
    }
}