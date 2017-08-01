using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class ZBSetUp : MonoBehaviour {

    // Use this for initialization
    Transform currentButton;
    public Button Equip;
    public Button Hat;
    public Button Clothes;
    System.Random randomNumber;
    public string[] rate;
    public TextAsset Rate;
    public string[] currentTerm1;
    void Start () {
        randomNumber = new System.Random();
        rate = Rate.text.Split('\n');
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetUp()
    {
        currentButton = EventSystem.current.currentSelectedGameObject.transform;


        //找这个装备
        for (int a = 1; a < 7; a++)
        {
            for (int b = 1; b < 4; b++)
            {
                if (currentButton.Find(a.ToString() + "-" + b.ToString()).gameObject.activeSelf)
                {

                    Singleton.Instance.objName = a.ToString() + "-" + b.ToString();
                    Debug.Log(Singleton.Instance.objName);
                    currentButton.Find(a.ToString() + "-" + b.ToString()).gameObject.GetComponent<AttributesEquip>().getInformation();

                }

            }
        }
    }
    public void SetEquip()
    {
        if(Singleton.Instance.type == 1.ToString())
        {
            isEmpty(Equip);
            Equip.transform.Find(Singleton.Instance.objName).gameObject.SetActive(true);
        }
        else if(Singleton.Instance.type == 2.ToString())
        {
            isEmpty(Clothes);
            Clothes.transform.Find(Singleton.Instance.objName).gameObject.SetActive(true);
        }
        else if(Singleton.Instance.type == 3.ToString())
        {
            isEmpty(Hat);
            Hat.transform.Find(Singleton.Instance.objName).gameObject.SetActive(true);
        }
        Debug.Log("啊啊啊啊啊啊");
        AdditionAttribute.atk = Convert.ToInt16(Singleton.Instance.currentTerm[7]);
        Debug.Log(AdditionAttribute.atk);
        AdditionAttribute.maatk = Convert.ToInt16(Singleton.Instance.currentTerm[8]);
        AdditionAttribute.def = Convert.ToInt16(Singleton.Instance.currentTerm[9]);
        AdditionAttribute.madef = Convert.ToInt16(Singleton.Instance.currentTerm[10]);
        AdditionAttribute.hp = Convert.ToInt16(Singleton.Instance. currentTerm[11]);
        AdditionAttribute.mp = Convert.ToInt16(Singleton.Instance.currentTerm[12]);
    }
    public void isEmpty(Button button)
    {
        
        if (button.gameObject.GetComponentInChildren<Transform>() != null)
        {
            for(int i = 0; i < button.transform.childCount; i++)
            {
                button.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
            
        
    }
    public void LevelUp()
    {
        if (Singleton.Instance.currentID - Singleton.Instance.id < 29)
        {
            for (int i = 0; i < rate.Length; i++)
            {
                string[] fields = rate[i].Split(',');
                if (Singleton.Instance. currentTerm[4] == fields[0] && Singleton.Instance.currentTerm[5] == fields[1])
                {
                    //强化成功了
                    if (ifLevelUp(fields[2]))
                    {
                       Singleton.Instance. currentID += 1;
                        
                        //强化成功标志
                        AdditionAttribute.atk = Convert.ToInt16(Singleton.Instance.currentTerm[7]);
                        Debug.Log(AdditionAttribute.atk);
                        AdditionAttribute.maatk = Convert.ToInt16(Singleton.Instance.currentTerm[8]);
                        AdditionAttribute.def = Convert.ToInt16(Singleton.Instance.currentTerm[9]);
                        AdditionAttribute.madef = Convert.ToInt16(Singleton.Instance.currentTerm[10]);
                        AdditionAttribute.hp = Convert.ToInt16(Singleton.Instance.currentTerm[11]);
                        AdditionAttribute.mp = Convert.ToInt16(Singleton.Instance.currentTerm[12]);
                    }
                    //强化没成功
                    else if (!ifLevelUp(fields[2]))
                    {
                        //需要降级吗
                        if (fields[11] == "1")
                        {
                            Singleton.Instance. currentID -= 1;
                            //强化失败标志

                        }
                        //强化失败标志

                    }
                }
                Singleton.Instance.currentButton.GetComponent<AttributesEquip>().idManage();

            }


        }
    }


    bool ifLevelUp(string percentage)
    {
        int percent = Convert.ToInt16(percentage);
        int randomNum = GetRandom();
        if (randomNum <= percent)
        {
            return true;
        }
        return false;
    }


    int GetRandom()
    {
        return randomNumber.Next(100);
    }

}
