using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManeger : MonoBehaviour
{

    [SerializeField] Text ExpText;
    int Exp;
    public static ExpManeger instance;
    AudioSource audioSource;
    public AudioClip getsound;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ExpBarDraw()
    {//ŒoŒ±’l‚ğE‚Á‚½‚ÉŒÄ‚Ño‚³‚ê‚é
        Exp++;
        ExpText.text = Exp.ToString();
    }
}
