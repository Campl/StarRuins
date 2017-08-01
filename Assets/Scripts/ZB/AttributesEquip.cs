using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class AttributesEquip : MonoBehaviour {

    public int id;
    public int currentID;
    public TextAsset csvFile;
    public TextAsset Rate;
    public string[] records;
    public string[] currentTerm;
    public GameObject textButton;
    System.Random randomNumber;
    public string[] rate;
    public Text buffButton;
    public CalculateAttribute aaa;
    
    void Start () {
        records = csvFile.text.Split('\n');
        randomNumber = new System.Random();
        rate = Rate.text.Split('\n');
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void getInformation()
    {
        if (Singleton.Instance.currentID  <= Singleton.Instance.id)
            currentID = id;
        Singleton.Instance.currentButton = this.gameObject;
        Singleton.Instance.id = id;
        Singleton.Instance.currentID = currentID;
        for (int i = 0; i < records.Length; i++)
        {
            string[] fields = records[i].Split(',');
            if (fields[0] == currentID.ToString())
            {
                textButton.transform.Find("describeText").GetComponent<Text>().text = "升阶级别：" + fields[5] + "强化级别：" + fields[6] + "附加物攻：" + fields[7] + "附加魔攻：" + fields[8] + "附加魔防：" + fields[9] + "附加hp：" + fields[10] + "附加mp" + fields[11];
                currentTerm = fields;
                Singleton.Instance.currentTerm = currentTerm;
                Singleton.Instance.type = currentTerm[3];

            }


        }
        for (int i = 0; i < rate.Length; i++)
        {
            string[] fields = rate[i].Split(',');
            if (currentTerm[4] == fields[0] && currentTerm[5] == fields[1])
            {
                buffButton.text = fields[4];
                
            }
        }

    }
    
    public void idManage()
    {
        currentID = Singleton.Instance.currentID;
        
    }


}
