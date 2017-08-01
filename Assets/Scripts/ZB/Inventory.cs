using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    public List<GameObject> grid;//格子列表，用来存储所有个物品格子
    Transform child;
    bool isNull = true;
    public void AddItem()
    {

        //查找每个格子，寻找空格子的物体。
        for (int i = 0; i < 40; i++)
        {
            for (int a = 1; a < 7; a++)
            {
                for (int b = 1; b < 4; b++)
                {
                    if (grid[i].transform.Find(a.ToString() + "-" + b.ToString()).gameObject.activeSelf)
                    {
                        isNull = false;
                    }
                }
            } 
            
            if (isNull)
            {
                goNext(grid[i]);
                break;
            }
            isNull = true;
        }
        
    }
    public void goNext(GameObject grid)
    {
        grid.transform.Find(Singleton.Instance.objName).gameObject.SetActive(true);

    }
}

