using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DroneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject RayPrefab;
    [SerializeField]
    StatusData RayStatus;
    GameObject Player;
    Vector2 PlayerPos;
    Vector2 myPos;
    GameObject[] targets;
    int DroneQuantity;
    float localdistance;
    private float currentTime;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//PlayerというTagを持つオブジェクト検索する。
        PlayerPos = Player.transform.position;
        this.transform.parent = Player.transform;//生成された時自分自身をプレイヤーの子要素にする
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > RayStatus.SPAN)
        {
            Debug.Log("RayStatus.SPAN:" + RayStatus.SPAN);
            RayGenerate();
            currentTime = 0f;
        }
    }

    public void RayGenerate()
    {
        AudioManager.Instance.PlaySE("ショット命中", 0.1f);
        var ray = Instantiate(RayPrefab, transform.position, transform.rotation);
        ray.tag = "Drone"; // 新しく生成されたドローンにDroneタグを付ける

        // ドローンが生成された後に、ドローンの数と位置を更新
        Search();
        PositionSet();
    }

    void Search()
    {
        targets = GameObject.FindGameObjectsWithTag("Drone");//Droneタグを持つオブジェクトを検索する
        foreach (var t in targets)
        {
            DroneQuantity = targets.Length;//Droneタグのオブジェクトの数を保存する
        }
    }
    void PositionSet()
    {
        //自分が何個目なのかによってポジションを決める
        localdistance = 1.0f;//主人公との距離
        myPos = Player.transform.position;
        switch (DroneQuantity)
        {
            case 1://1個目の場合
                myPos.x = 1;
                myPos.y = 1;
                transform.localPosition = myPos;
                break;
            case 2://2個目の場合
                myPos.x = -1 ;
                myPos.y = -1 ;
                transform.localPosition = myPos;
                break;
            case 3://3一個目の場合
                myPos.x = -1 ;
                myPos.y = 1;
                transform.localPosition = myPos;
                break;
            case 4://4個目の場合
                myPos.x = 1;
                myPos.y = -1;
                transform.localPosition = myPos;
                break;
            case 5://5個目の場合
                myPos.x = 0;
                myPos.y = 5f;
                transform.localPosition = myPos;
                break;
        }
    }
}