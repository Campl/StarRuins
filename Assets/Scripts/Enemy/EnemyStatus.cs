using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour {
    public Attack attack;
    public string Name="暗影兽";
    public float hp=48;
	public float hp_max=48;
    public int level=1;//怪物等级
    public int exp=60;//怪物提供经验
    public int maatk=0;//魔法攻击力
    public int madef=26;//魔法防御力
    public int atk=30;//物理攻击力
    public int def=22;//物理防御力
    public float crirRate=5;//暴击率
    public float crirRatio=1.1f;//暴击伤害比率(造成普通攻击n倍伤害)
    public float atk_range=1;//攻击范围
    public float speed = 0.03f;//移动速度

	public bool Patk=false;

    public Slider hpSlider;
    // Use this for initialization
    void Start () {
        hpSlider.maxValue = hp;
        hpSlider.value = hp;
    }
	
	// Update is called once per frame
	void Update () {
        hpSlider.value = hp;
		if (hp <= 0) {
			Invoke ("destroy", 0.8f);

		}
           
	}

	private void destroy() {
		Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerHit")
        {         
            hp -= attack.Damage(CurrentAttribute.atk, def, CurrentAttribute.crirRate, CurrentAttribute.crirRatio);
			Patk = true;
        }
    }
}
