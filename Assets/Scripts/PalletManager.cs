using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;

public class PalletManager : MonoBehaviour
{
    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        datapath = Application.dataPath + "/TestJson.json";
    }

    public static PalletManager _instance;

    //----------------------------------------------------------------------

    public int Width;
    public int Height;

    private int SelectSprite;

    //----------------------------------------------------------------------

    public Transform Horizon;
    public GameObject Vertical;
    public GameObject block;
    public GameObject[] blocks;
    public GameObject image;

    public class Save_Data
    {
        public List<int> block_vlue = new List<int>();
        public List<int> block_pos_x = new List<int>();
        public List<int> block_pos_y = new List<int>();
        public int Width;
        public int Height;
    }

    public Save_Data save_Data = new Save_Data();
    public string datapath;
    public Text datapath_text;

    //----------------------------------------------------------------------

    private void Start()
    {
        datapath_text.text = datapath;
    }

    //----------------------------------------------------------------------
    public int SelectProperty
    {
        get { return SelectSprite; }
        set { SelectSprite = value; }
    }

    //----------------------------------------------------------------------

    public void Set_Block()
    {
        for(int i = 0; i < Width; i++)
        {
            var verticalbox = Instantiate(Vertical, Horizon);
            for (int j = Height-1; j >= 0; j--)
            {
                var obj = Instantiate(block, verticalbox.transform);
                obj.GetComponent<FieldButton>().Pos_X = i;
                obj.GetComponent<FieldButton>().Pos_Y = j;
            }
        }
    }

    //----------------------------------------------------------------------

    public void Save_Button()
    {
        for(int i = 0; i < Width; i++)
        {
            for(int j = 0; j < Height; j++)
            {
                blocks = GameObject.FindGameObjectsWithTag("block");
            }
        }
    }

    //----------------------------------------------------------------------

    public void Export_Button()
    {
        if(blocks == null)
        {
            Debug.Log("null");
            return;
        }
        for(int i = 0; i < blocks.Length; i++)
        {
            int value  = blocks[i].GetComponent<FieldButton>().Color_num;
            int x = blocks[i].GetComponent<FieldButton>().Pos_X;
            int y = blocks[i].GetComponent<FieldButton>().Pos_Y;

            save_Data.block_vlue.Add(value);
            save_Data.block_pos_x.Add(x);
            save_Data.block_pos_y.Add(y);
            save_Data.Width = Width;
            save_Data.Height = Height;
        }

        for(int i = 0; i < save_Data.block_vlue.Count; i++)
        {
            Debug.Log("Value : " + save_Data.block_vlue[i] +
                " Pos_X : " + save_Data.block_pos_x[i] +
                " Pos_Y : " + save_Data.block_pos_y[i]);
        }
        Debug.Log("Width : " + save_Data.Width + " Height : " + save_Data.Height);

        string json = LitJson.JsonMapper.ToJson(save_Data);

        StreamWriter writer;

        writer = new StreamWriter(datapath, false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
        //image.SetActive(true);
    }
}
