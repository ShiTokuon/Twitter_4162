using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] StatusData statusdata;
    public Slider hpSlider;
    float HP;
    // Start is called before the first frame update
    void Start()
    {
        if (hpSlider != null)
        {
            hpSlider.maxValue = statusdata.MAXHP;
            hpSlider.value = statusdata.MAXHP;
        }
        HP = statusdata.MAXHP;
    }
}