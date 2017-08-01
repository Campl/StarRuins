using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {

    public string objName;
    public int cost;
    public string describe;
    public string role;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Find("itemText").Find("jobText").GetComponent<Text>().text = role;
        transform.Find("itemText").Find("describeText").GetComponent<Text>().text = describe;
        transform.Find("itemText").Find("nameText").GetComponent<Text>().text = objName;
        transform.Find("itemText").Find("priceText").GetComponent<Text>().text = "价格：" +cost.ToString();
    }
}
