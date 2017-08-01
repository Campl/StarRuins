using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightManager : MonoBehaviour {
    public Text PlayerName;
    public Text Level;
    public Text Exp;
    public Slider ExpSlider;
    public Slider HpSlider;
    public Text Hp;
    public Slider MpSlider;
    public Text Mp;
    private string Name;
    private int role;
    CalculateAttribute calAttribute;
    // Use this for initialization
    void Start () {
        calAttribute = GetComponent<CalculateAttribute>();
        Name = PlayerPrefs.GetString("Name");
        PlayerName.text = Name;
    }
	
	// Update is called once per frame
	void Update () {
        Level.text = "LV." + BaseAttribute.level;
        ExpSlider.maxValue = BaseAttribute.exp2LevelUp;
        ExpSlider.value = BaseAttribute.exp;
        Exp.text = BaseAttribute.exp + "/" + BaseAttribute.exp2LevelUp;
        HpSlider.maxValue = SumAttribute.hp;
        HpSlider.value = CurrentAttribute.hp;
        Hp.text = CurrentAttribute.hp + "/" + SumAttribute.hp;
        MpSlider.maxValue = SumAttribute.mp;
        MpSlider.value = CurrentAttribute.mp;
        Mp.text = CurrentAttribute.mp + "/" + SumAttribute.mp;
    }
}
