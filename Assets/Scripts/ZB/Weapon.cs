using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Weapon : MonoBehaviour {

    public TextAsset csvFile;

    System.Random randomNumber;
    String[] records;
    List<String[]> field;



    // 需要提前判定职业







    void Start () {
        randomNumber = new System.Random();
        readCSV();
        
    }
	
	
    void readCSV()
    {
        
        records = csvFile.text.Split('\n');
        for(int i = 0; i < records.Length; i++)
        {
            string[] fields = records[i].Split(',');
            Debug.Log(fields[0]);
            
        }
        
    }
   
    
    public string[] LevelUp( List<string[]> weapon, string[] currentTerm)
    {
        string[] term;
        // 按了强化按钮

        // 判断是否强化成功
        int need = Convert.ToInt16(currentTerm[7]);

        for(int i =  0; i < weapon.Count; i++)
        {
            if(weapon[i] == currentTerm)
            {
                // 判断是否有钱 & 打造成功了吗
                if (ifLevelUp(currentTerm[9]))
                {
                    //有没有强化到最高级
                    if(currentTerm[4] != "3" && currentTerm[5] != "10")
                    {
                        //到下一级
                        term = weapon[i + 1];
                        
                        
                        
                        //++扣钱++//
                        return term;
                    }
                    
                }
                if (!ifLevelUp(currentTerm[9]))
                {
                    Debug.Log("几率没到！");
                }
                
                if (currentTerm[4] == "3" && currentTerm[5] == "10")
                {
                    Debug.Log("已强化到最高级啦！");
                }
            }
            
        }
        return currentTerm;

    }
    bool ifLevelUp(string percentage)
    {
        string newPercent;
        newPercent = percentage.Replace("%", "");
        int percent = Convert.ToInt16(newPercent);
        int randomNum = GetRandom();
        if(randomNum <= percent)
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
