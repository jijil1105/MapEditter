using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletButton : MonoBehaviour
{
    public GameObject[] Marker;
    public GameObject palletManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectButton(int num)
    {
        if(num == PalletManager._instance.SelectProperty)
        {
            Marker[num].SetActive(false);
            PalletManager._instance.SelectProperty = 0;
        }
        else if(PalletManager._instance.SelectProperty == 0)
        {
            Marker[num].SetActive(true);
            PalletManager._instance.SelectProperty = num;
        }
        else
        {
            Marker[PalletManager._instance.SelectProperty].SetActive(false);
            Marker[num].SetActive(true);
            PalletManager._instance.SelectProperty = num;
        }
    }
}
