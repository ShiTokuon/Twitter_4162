using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ExpOrbScript : MonoBehaviour
{
    [SerializeField] Text ExpText;
    public int Exp;

    void Start()
    {
    }

    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySE("poka", 0.5f);
            Exp++;
            ExpText.text = Exp.ToString();
            ExpManeger.instance.ExpBarDraw();//経験値を拾った時に経験値バーの描画を更新する
            Destroy(this.gameObject);
        }
    }
}
