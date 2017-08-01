using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public GameObject Roleimage1;
    public GameObject Roleimage2;
    public GameObject Roleimage3;
    public GameObject Roleimage4;
    public GameObject Skillimage1;
    public GameObject Skillimage2;
    public GameObject Skillimage3;
    public GameObject Skillimage4;
    public Text PlayerName;
    public Text PlayerRole;
    public Text Level;
    public Text Exp;
    public Slider ExpSlider;
    public Slider HpSlider;
    public Text Hp;
    public Slider MpSlider;
    public Text Mp;
    public Text PhyAtk;
    public Text MagAtk;
    public Text PhyDef;
    public Text MagDef;
    public Text CrRate;
    public Text CrDmg;
    private string Name;
    private int role;

    CalculateAttribute calAttribute;
    // Use this for initialization
    void Start () {
        calAttribute = GetComponent<CalculateAttribute>();
        role =PlayerPrefs.GetInt("Role");
        Name = PlayerPrefs.GetString("Name");
        PlayerName.text = Name;

        switch (role)
        {
            case 1:
                Roleimage1.SetActive(true);
                Skillimage1.SetActive(true);
                PlayerRole.text = "星破";
                break;
            case 2:
                Roleimage2.SetActive(true);
                Skillimage2.SetActive(true);
                PlayerRole.text = "星羽";
                break;
            case 3:
                Roleimage3.SetActive(true);
                Skillimage3.SetActive(true);
                PlayerRole.text = "星邪";
                break;
            case 4:
                Roleimage4.SetActive(true);
                Skillimage4.SetActive(true);
                PlayerRole.text = "星阵";
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        calAttribute.UpdateAttribute();
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
        PhyAtk.text = SumAttribute.atk.ToString();
        MagAtk.text = SumAttribute.maatk.ToString();
        PhyDef.text = SumAttribute.def.ToString();
        MagDef.text = SumAttribute.madef.ToString();
        CrRate.text = SumAttribute.crirRate.ToString();
        CrDmg.text = SumAttribute.crirRatio.ToString();

    }
}
