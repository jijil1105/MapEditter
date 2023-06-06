using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldButton : MonoBehaviour
{
    public int Color_num = 0;
    public Color[] Pattern;
    public int Pos_X;
    public int Pos_Y;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PushButton()
    {
        if(Input.GetMouseButton(0) == false)
        {
            return;
        }

        if(PalletManager._instance.SelectProperty == 0)
        {
            this.gameObject.GetComponent<Image>().color = Pattern[PalletManager._instance.SelectProperty];
            Color_num = PalletManager._instance.SelectProperty;
            Debug.Log("X : " + Pos_X + " Y : " + Pos_Y);
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = Pattern[PalletManager._instance.SelectProperty];
            Color_num = PalletManager._instance.SelectProperty;
            Debug.Log("X : " + Pos_X + " Y : " + Pos_Y);
        }
    }
}