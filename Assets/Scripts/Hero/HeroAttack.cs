using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour {
    public HeroControl Hero;
    public CalculateAttribute cal;
    public Rigidbody bPrefab;
    float attack_start;
    public bool ifattack;

    
    // Use this for initialization
    void Start () {
        attack_start = 0;
        InvokeRepeating("TimeCounting", 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (ETCInput.GetButton("attackButton")  && ifattack)
        {
            Debug.Log("开始攻击");
            CreAttack();
            ifattack = false;
        }
    }

    //创建攻击碰撞体  
    public void CreAttack()
    {
        Rigidbody bullet = Instantiate(bPrefab, transform.position, Quaternion.identity) as Rigidbody;
        bullet.tag = "PlayerHit";
        if(Hero.tran==1)
            bullet.AddForce(Vector3.right * 500);
        else
            bullet.AddForce(Vector3.left * 500);
    }
    //攻击计时
    void TimeCounting()
    {
        attack_start += 1;
        if (attack_start != 0 && attack_start % 1 == 0)
        {
            ifattack = true;
        }
    }
}
