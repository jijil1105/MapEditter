using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    public Button button_Enter;
    public Text text_width;
    public Text text_height;
    public enum P
    {
        Width,
        Height
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick_Button_Width(int value)
    {
        PalletManager._instance.Width += value;
        text_width.text = PalletManager._instance.Width.ToString();
    }

    public void Onclick_Button_Height(int value)
    {
        PalletManager._instance.Height += value;
        text_height.text = PalletManager._instance.Height.ToString();
    }
}
