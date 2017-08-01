using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

public class ZBBuy : MonoBehaviour
{

    public Button buyButton;
    bool ifBuy;
    public Inventory inventory;
    GameObject gameObj;
    Transform currentButton;

    void Start()
    {
        ifBuy = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ObjSet()
    {
        buyButton.enabled = true;
        currentButton = EventSystem.current.currentSelectedGameObject.transform;


            //找这个装备
        for (int a = 1; a < 7; a++)
            {
                for (int b = 1; b < 4; b++)
                {
                    if (currentButton.Find(a.ToString() + "-" + b.ToString()) != null)
                    {
                    
                    Singleton.Instance.objName = a.ToString() + "-" + b.ToString();
                    //Debug.Log(Singleton.Instance.objName);

                    }

                }
            }
        

    }
    public void buy()
    {
        inventory.AddItem();
    }
    public void AddOn()
    {
        
    }

}
