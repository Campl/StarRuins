using System.Collections;
using System.Collections.Generic;    //public SumAttribute SumAttribute;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAttribute : MonoBehaviour
{
    public int maxLevel = 30;
    public int exp2LevelUp;

    //public BaseAttribute baseStatus;
    //public AdditionAttribute AdditionAttribute;
    //public SumAttribute SumAttribute;
    //public CurrentAttribute CurrentAttribute;

   // public Slider hpSlider;
    //public Text hpText;
    //public Slider mpSlider;
   // public Text mpText;
   // public Slider expSlider;
   // public Text expText;
    //public Text nameText;
   // public Text levelText;

    bool getLevelUp = false;

    public void calculateExp()
    {
        //每级所需经验：Floor(((等级 - 1)^3 + 60) / 4 * ((等级 - 1) * 2 + 60),50)
        float timePerLevel = (BaseAttribute.level - 1) * (BaseAttribute.level - 1) * (BaseAttribute.level - 1) + 60;
        float expPerEnemy = (BaseAttribute.level - 1) * 2 + 60;
        exp2LevelUp = Mathf.FloorToInt(timePerLevel / 4.0f * expPerEnemy);
        exp2LevelUp -= exp2LevelUp % 50;
        BaseAttribute.exp2LevelUp = exp2LevelUp;
    }

    //更新经验值
    public void UpdateExp()
    {
        if (BaseAttribute.level >= maxLevel)
        {
            BaseAttribute.level = maxLevel;
        }
        else
        {
            if (BaseAttribute.exp >= exp2LevelUp)
            {
                getLevelUp = true;
                BaseAttribute.exp -= exp2LevelUp;
                BaseAttribute.level++;

                calculateExp();//更新升级所需经验
                UpdateAttribute();

                //升级回复hp mp
                CurrentAttribute.hp = SumAttribute.hp;
                CurrentAttribute.mp = SumAttribute.mp;
            }
        }
    }

    //更新属性
    public void UpdateAttribute()
    {
        if (getLevelUp)
        {
            //属性点增加
            BaseAttribute.vit++;
            BaseAttribute.str++;
            BaseAttribute.inte++;
            BaseAttribute.sta++;

            UpdateBaseAttribute();
            getLevelUp = false;
        }

        SumAttribute.vit = BaseAttribute.vit + AdditionAttribute.vit;
        SumAttribute.str = BaseAttribute.str + AdditionAttribute.str;
        SumAttribute.spr = BaseAttribute.spr + AdditionAttribute.spr;
        SumAttribute.inte = BaseAttribute.inte + AdditionAttribute.inte;
        SumAttribute.sta = BaseAttribute.sta + AdditionAttribute.sta;
        UpdateSumAttribute();

        //更新当前属性
        CurrentAttribute.vit = SumAttribute.vit;
        CurrentAttribute.str = SumAttribute.str;
        CurrentAttribute.spr = SumAttribute.spr;
        CurrentAttribute.inte = SumAttribute.inte;
        CurrentAttribute.sta = SumAttribute.sta;

        CurrentAttribute.atk = SumAttribute.atk;
        CurrentAttribute.maatk = SumAttribute.maatk;
        CurrentAttribute.def = SumAttribute.def;
        CurrentAttribute.madef = SumAttribute.madef;

        CurrentAttribute.crirRate = SumAttribute.crirRate;
        CurrentAttribute.crirRatio = SumAttribute.crirRatio;
        CurrentAttribute.atk_range = SumAttribute.atk_range;
        CurrentAttribute.atk_cd = SumAttribute.atk_cd;
        CurrentAttribute.speed = SumAttribute.speed;
        CurrentAttribute.jumpHeight = SumAttribute.jumpHeight;

        CheckHpMp();
        //hpSlider.maxValue = SumAttribute.hp;
        //hpSlider.value = CurrentAttribute.hp;
        //hpText.text = CurrentAttribute.hp.ToString();
        //mpSlider.maxValue = SumAttribute.mp;
        //mpSlider.value = CurrentAttribute.mp;
        //mpText.text = CurrentAttribute.mp.ToString();
       // expSlider.maxValue = exp2LevelUp;
       // expSlider.value = BaseAttribute.exp;
        //expText.text = expSlider.value + "/" + expSlider.maxValue;
       // levelText.text = BaseAttribute.level.ToString();
    }

    //检查hpmp保证在0~上限之内
    public void CheckHpMp()
    {
        if (CurrentAttribute.hp < 0)
        {
            CurrentAttribute.hp = 0;
        }
        if (CurrentAttribute.mp < 0)
        {
            CurrentAttribute.mp = 0;
        }
        if (CurrentAttribute.hp > SumAttribute.hp)
        {
            CurrentAttribute.hp = SumAttribute.hp;
        }
        if (CurrentAttribute.mp > SumAttribute.mp)
        {
            CurrentAttribute.mp = SumAttribute.mp;
        }
    }

    //根据属性点更新基础属性
    private void UpdateBaseAttribute()
    {
        if (BaseAttribute.name == "Hero")
        {
            BaseAttribute.hp = Mathf.CeilToInt(BaseAttribute.vit * 6.0f + 50);
            BaseAttribute.mp = Mathf.CeilToInt(BaseAttribute.inte * 1.0f + 15);
            BaseAttribute.atk = Mathf.CeilToInt(BaseAttribute.str * 2.4f + 27);
            BaseAttribute.maatk = 0;
            BaseAttribute.def = Mathf.CeilToInt(BaseAttribute.sta * 3.0f + 20);
            BaseAttribute.madef = Mathf.CeilToInt(BaseAttribute.inte * 2.5f + 15);
        }
        if (BaseAttribute.name == "Enemy_General")
        {
            BaseAttribute.hp = Mathf.CeilToInt(BaseAttribute.vit * 4.8f + 28);
            BaseAttribute.mp = 0;
            BaseAttribute.atk = Mathf.CeilToInt(BaseAttribute.str * 3.3f + 28);
            BaseAttribute.maatk = 0;
            BaseAttribute.def = Mathf.CeilToInt(BaseAttribute.sta * 1.2f + 20);
            BaseAttribute.madef = 0;
        }
        if (BaseAttribute.name == "Enemy_Elite")
        {
            BaseAttribute.hp = Mathf.CeilToInt(BaseAttribute.vit * 24f + 240);
            BaseAttribute.mp = 0;
            BaseAttribute.atk = Mathf.CeilToInt(BaseAttribute.str * 3.7f + 29);
            BaseAttribute.maatk = 0;
            BaseAttribute.def = Mathf.CeilToInt(BaseAttribute.sta * 2.0f + 23);
            BaseAttribute.madef = 0;
        }
        if (BaseAttribute.name == "Enemy_Boss")
        {
            BaseAttribute.hp = Mathf.CeilToInt(BaseAttribute.vit * 36f + 360);
            BaseAttribute.mp = 0;
            BaseAttribute.atk = Mathf.CeilToInt(BaseAttribute.str * 4.0f + 32);
            BaseAttribute.maatk = 0;
            BaseAttribute.def = Mathf.CeilToInt(BaseAttribute.sta * 2.2f + 25);
            BaseAttribute.madef = 0;
        }
    }

    //根据属性点更新总属性
    private void UpdateSumAttribute()
    {
        if (BaseAttribute.name == "Hero")
        {
            //总属性=基础属性+额外直接加成属性+额外间接加成属性
            SumAttribute.hp = BaseAttribute.hp + AdditionAttribute.hp + Mathf.CeilToInt(AdditionAttribute.vit * 5.0f);
            SumAttribute.mp = BaseAttribute.mp + AdditionAttribute.mp + Mathf.CeilToInt(AdditionAttribute.inte * 1.5f);
            SumAttribute.atk = BaseAttribute.atk + AdditionAttribute.atk + Mathf.CeilToInt(AdditionAttribute.str * 3.2f);
            SumAttribute.maatk = BaseAttribute.maatk + AdditionAttribute.maatk + Mathf.CeilToInt(AdditionAttribute.spr );
            SumAttribute.def = BaseAttribute.def + AdditionAttribute.def + Mathf.CeilToInt(AdditionAttribute.sta * 2.6f);
            SumAttribute.madef = BaseAttribute.madef + AdditionAttribute.madef + Mathf.CeilToInt(AdditionAttribute.inte * 2.5f);
        }
        if (BaseAttribute.name == "Enemy_General")
        {
            SumAttribute.hp = BaseAttribute.hp + AdditionAttribute.hp + Mathf.CeilToInt(AdditionAttribute.vit * 4.8f);
            SumAttribute.mp = BaseAttribute.mp + AdditionAttribute.mp + Mathf.CeilToInt(AdditionAttribute.inte * 0.0f);
            SumAttribute.atk = BaseAttribute.atk + AdditionAttribute.atk + Mathf.CeilToInt(AdditionAttribute.str * 3.3f);
            SumAttribute.maatk = BaseAttribute.maatk + AdditionAttribute.maatk + Mathf.CeilToInt(AdditionAttribute.spr + 0.0f);
            SumAttribute.def = BaseAttribute.def + AdditionAttribute.def + Mathf.CeilToInt(AdditionAttribute.sta * 1.2f);
            SumAttribute.madef = BaseAttribute.madef + AdditionAttribute.madef + Mathf.CeilToInt(AdditionAttribute.inte * 0.0f);
        }
        if (BaseAttribute.name == "Enemy_Elite")
        {
            SumAttribute.hp = BaseAttribute.hp + AdditionAttribute.hp + Mathf.CeilToInt(AdditionAttribute.vit * 24.0f);
            SumAttribute.mp = BaseAttribute.mp + AdditionAttribute.mp + Mathf.CeilToInt(AdditionAttribute.inte * 0.0f);
            SumAttribute.atk = BaseAttribute.atk + AdditionAttribute.atk + Mathf.CeilToInt(AdditionAttribute.str * 3.7f);
            SumAttribute.maatk = BaseAttribute.maatk + AdditionAttribute.maatk + Mathf.CeilToInt(AdditionAttribute.spr + 0.0f);
            SumAttribute.def = BaseAttribute.def + AdditionAttribute.def + Mathf.CeilToInt(AdditionAttribute.sta * 2.0f);
            SumAttribute.madef = BaseAttribute.madef + AdditionAttribute.madef + Mathf.CeilToInt(AdditionAttribute.inte * 0.0f);
        }
        if (BaseAttribute.name == "Enemy_Boss")
        {
            SumAttribute.hp = BaseAttribute.hp + AdditionAttribute.hp + Mathf.CeilToInt(AdditionAttribute.vit * 36.0f);
            SumAttribute.mp = BaseAttribute.mp + AdditionAttribute.mp + Mathf.CeilToInt(AdditionAttribute.inte * 0.0f);
            SumAttribute.atk = BaseAttribute.atk + AdditionAttribute.atk + Mathf.CeilToInt(AdditionAttribute.str * 4.0f);
            SumAttribute.maatk = BaseAttribute.maatk + AdditionAttribute.maatk + Mathf.CeilToInt(AdditionAttribute.spr + 0.0f);
            SumAttribute.def = BaseAttribute.def + AdditionAttribute.def + Mathf.CeilToInt(AdditionAttribute.sta * 2.2f);
            SumAttribute.madef = BaseAttribute.madef + AdditionAttribute.madef + Mathf.CeilToInt(AdditionAttribute.inte * 0.0f);
        }

        SumAttribute.crirRate = BaseAttribute.crirRate + AdditionAttribute.crirRate;
        SumAttribute.crirRatio = BaseAttribute.crirRatio + AdditionAttribute.crirRatio;

        SumAttribute.atk_range = BaseAttribute.atk_range + AdditionAttribute.atk_range;
        SumAttribute.atk_cd = BaseAttribute.atk_cd + AdditionAttribute.atk_cd;
        SumAttribute.speed = BaseAttribute.speed + AdditionAttribute.speed;
        SumAttribute.jumpHeight = BaseAttribute.jumpHeight + AdditionAttribute.jumpHeight;
    }

    void Awake()
    {
        //BaseAttribute = GetComponent<BaseAttribute>();
        //AdditionAttribute = GetComponent<AdditionAttribute>();
        //CurrentAttribute = GetComponent<CurrentAttribute>();
        //SumAttribute = GetComponent<SumAttribute>();
    }

    void Start()
    {
        //initialize
        BaseAttribute.name = "Hero";

        calculateExp();
        UpdateBaseAttribute();

        UpdateAttribute();
        CurrentAttribute.hp = SumAttribute.hp;
        CurrentAttribute.mp = SumAttribute.mp;

      //  hpSlider.maxValue = SumAttribute.hp;
      //  hpSlider.value = SumAttribute.hp;
       // hpText.text = SumAttribute.hp.ToString();
      //  mpSlider.maxValue = SumAttribute.mp;
       // mpSlider.value = SumAttribute.mp;
      //  mpText.text = SumAttribute.mp.ToString();
       // expSlider.maxValue = exp2LevelUp;
       // expSlider.value = BaseAttribute.exp;
       // expText.text = expSlider.value + "/" + expSlider.maxValue;
       // levelText.text = BaseAttribute.level.ToString();
    }

    void Update()
    {
    }

}
