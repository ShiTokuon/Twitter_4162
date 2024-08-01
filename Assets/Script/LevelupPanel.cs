using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelupPanel : MonoBehaviour
{
    public static LevelupPanel instance;
    Text itemText;
    //public GamemanegerScript GMscript;
    string ItemName;
    GameObject Player;

    [SerializeField] GameObject LevelUPUI;
    Image itemimage;

    public float originalATK;
    public float originalHP;
    public float originalSPEED;

    public Image Imagename;
    //public GamemanegerScript GMscript;
    [SerializeField] GameObject drone;
    [SerializeField] StatusData statusdata;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Player = GameObject.FindGameObjectWithTag("Player");

        statusdata.ATK = originalATK;
        statusdata.MAXHP = originalHP;
        statusdata.SPEED = originalSPEED;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelPanelprocess()
    {

    }

    public void Onclick()
    {
        Imagename = this.gameObject.GetComponent<Image>();
        if (Imagename == null)
        {
            Debug.LogError("Imagename is null. Trying to get the Image component again.");
            Imagename = this.gameObject.AddComponent<Image>();
        }
        Debug.Log(Imagename.sprite.name);
        if (Imagename.sprite.name == "ItemPanel0")
        {
            Debug.Log("移動スピードアップを選択");
            statusdata.SPEED++;
        }

        if (Imagename.sprite.name == "ItemPanel1")
        {
            Debug.Log("攻撃力アップを選択");
            statusdata.ATK++;
        }

        if (Imagename.sprite.name == "ItemPanel2")
        {
            Player.gameObject.GetComponent<PlayerHP>().Heal(20);
            Debug.Log("回復を選択");
        }

        Time.timeScale = 1;
        LevelUPUI.GetComponent<Canvas>().enabled = false;
    }
}