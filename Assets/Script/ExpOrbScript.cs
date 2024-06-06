using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ExpOrbScript : MonoBehaviour
{
    [SerializeField] Text ExpText;
    public int Exp;

    public AudioClip sound; // getsoundをsoundに変更
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(sound);
            Exp++;
            ExpText.text = Exp.ToString();
            ExpManeger.instance.ExpBarDraw();//経験値を拾った時に経験値バーの描画を更新する
            Destroy(this.gameObject);
        }
    }
}
