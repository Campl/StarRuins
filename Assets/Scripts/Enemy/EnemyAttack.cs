using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public EnemyStatus ens;
    public Rigidbody bPrefab;
    public HeroControl Hero;
    float attack_start;
    bool ifattack;
    // Use this for initialization
    void Start () {
        attack_start = 0;
        InvokeRepeating("TimeCounting", 0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Hero.gameObject.transform.position.x - this.gameObject.transform.position.x) < ens.atk_range && ifattack)
        {
            //Debug.Log("怪物开始攻击");
            CreAttack();
            ifattack = false;
        }
    }
    void CreAttack()
    {
        Rigidbody bullet = Instantiate(bPrefab, transform.position, Quaternion.identity) as Rigidbody;
        bullet.tag = "EnemyHit";
        if (Hero.gameObject.transform.position.x>this.gameObject.transform.position.x)
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
            //Debug.Log("Reday");
        }
    }
}
