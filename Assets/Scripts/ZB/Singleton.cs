using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    static Singleton instance;
    public string objName;
    public string type;
    public string currentName;
    public int id;
    public int currentID;
    public string[] currentTerm;
    public GameObject currentButton;
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
    }
}
