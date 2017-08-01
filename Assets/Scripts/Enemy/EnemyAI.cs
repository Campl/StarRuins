using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
	public Animator animator;
    public HeroControl hero;
    public CapsuleCollider coll;
	public EnemyStatus enemy;

	public bool isAttacked = false;

    //怪物属性
    private int viewableRange = 20;

    //怪物类别
    public int id = 13;

    //普通攻击
    private float attack_value = 1;
    private float attack_range = 5;
    private float attack_CD = 1;
    private float attack_start = 0;

    //被动技能开关
    private bool skill_passive_on = false;
    private float skill_passive_value = 1.5f;

    //百分比扣血
    private float skill_hit_value = 0.03f;
    private float skill_hit_start = 0;
    private float skill_hit_duration = 10;
    private int skill_hit_count = 0;
    private int skill_hit_count_max = 10;
    private bool skill_hit_1 = true;
    private bool skill_hit_2 = true;
    private bool skill_hit_on = false;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<CapsuleCollider>();
		animator = GetComponent<Animator>();

		animator.SetBool ("Idle", true);
		animator.SetFloat ("die", 0.0f);
		animator.SetFloat ("hurt", 0.0f);
		if (id == 12) {
			animator.SetFloat ("attack", 0.0f);
		}
		if (id == 13) {
			animator.SetFloat ("attack", 0.0f);
			animator.SetFloat ("buff", 0.0f);
			animator.SetFloat ("skill", 0.0f);
			animator.SetFloat ("buff_on", 0.0f);
		}
    }
    // Update is called once per frame
    void Update()
    {
        //hero = Player;
        navigate();

        switch (id)
        {
            case 13:
			if (enemy.hp <= enemy.hp_max * 0.3 && !skill_passive_on)
                {
                    skill_passive();
                    skill_passive_on = true;

					animator.SetBool ("Idle", false);
					animator.SetFloat ("die", 0.0f);
					animator.SetFloat ("hurt", 0.0f);
					animator.SetFloat ("attack", 0.0f);
					animator.SetFloat ("buff", 1.0f);
					animator.SetFloat ("skill", 0.0f);
					animator.SetFloat ("buff_on", 1.0f);
                }
			if (skill_hit_1 && enemy.hp <= enemy.hp_max * 0.6 && enemy.hp > enemy.hp_max * 0.3)
                {
				Debug.Log ("技能开启");
                    skill_hit_1 = false;
                    skill_hit_start = Time.time;
                    skill_hit_on = true;

					animator.SetBool ("Idle", false);
					animator.SetFloat ("die", 0.0f);
					animator.SetFloat ("hurt", 0.0f);
					animator.SetFloat ("attack", 0.0f);
					animator.SetFloat ("skill", 1.0f);
                }
				if (skill_hit_2 && enemy.hp <= enemy.hp_max * 0.3)
                {
				Debug.Log ("技能开启");
                    skill_hit_2 = false;
                    skill_hit_start = Time.time;
                    skill_hit_on = true;
                    skill_hit_count = 0;
					animator.SetBool ("Idle", false);
					animator.SetFloat ("die", 0.0f);
					animator.SetFloat ("hurt", 0.0f);
					animator.SetFloat ("attack", 0.0f);
					animator.SetFloat ("skill", 1.0f);
                }
                if (Time.time - skill_hit_start > skill_hit_duration || skill_hit_count >= skill_hit_count_max)
                {
                    skill_hit_count = 0;
                    skill_hit_on = false;
					animator.SetFloat ("skill", 0.0f);
                }
                break;
        }

        normalAttack();

		//受伤
		if (enemy.Patk) {
			enemy.Patk = false;
			animator.SetBool ("Idle", false);
			animator.SetFloat ("die", 0.0f);
			animator.SetFloat ("hurt", 1.0f);
			if (id == 12) {
				animator.SetFloat ("attack", 0.0f);
			}
			if (id == 13) {
				animator.SetFloat ("attack", 0.0f);
			}

			Debug.Log (animator.GetBool("hurt"));
		}

		//死亡
		if (enemy.hp <= 0)
        {
			animator.SetBool ("Idle", false);
			animator.SetFloat ("die", 1.0f);
			animator.SetFloat ("hurt", 0.0f);
			if (id == 12) {
				animator.SetFloat ("attack", 0.0f);
			}
			if (id == 13) {
				animator.SetFloat ("attack", 0.0f);
				animator.SetFloat ("buff", 0.0f);
				animator.SetFloat ("skill", 0.0f);
				animator.SetFloat ("buff_on", 0.0f);
			}
        }
    }

    //寻路
    public void navigate()
    {
		if (Mathf.Abs(hero.gameObject.transform.position.x - this.gameObject.transform.position.x) > viewableRange)
		{
			return;
		}


        if (hero.gameObject.transform.position.x - this.gameObject.transform.position.x > (hero.HeroColl.radius * hero.transform.localScale.x + this.coll.radius * this.transform.localScale.x + 0.1))
        {
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + enemy.speed,
                this.gameObject.transform.position.y, this.gameObject.transform.position.z);

			animator.SetFloat ("dir", 1.0f);
			animator.SetBool ("Idle", true);
			animator.SetFloat ("die", 0.0f);
			animator.SetFloat ("hurt", 0.0f);
			if (id == 12) {
				animator.SetFloat ("attack", 0.0f);
			}
			if (id == 13) {
				animator.SetFloat ("attack", 0.0f);
			}

        }
        else if (hero.gameObject.transform.position.x - this.gameObject.transform.position.x <= (hero.HeroColl.radius * hero.transform.localScale.x + this.coll.radius * this.transform.localScale.x + 0.1) &&
           hero.gameObject.transform.position.x - this.gameObject.transform.position.x >= -1 * (hero.HeroColl.radius * hero.transform.localScale.x + this.coll.radius * this.transform.localScale.x + 0.1))
        {
        }
        else
        {
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - enemy.speed,
                this.gameObject.transform.position.y, this.gameObject.transform.position.z);

			animator.SetFloat ("dir", 0.0f);
			animator.SetBool ("Idle", true);
			animator.SetFloat ("die", 0.0f);
			animator.SetFloat ("hurt", 0.0f);
			if (id == 12) {
				animator.SetFloat ("attack", 0.0f);
			}
			if (id == 13) {
				animator.SetFloat ("attack", 0.0f);
			}
        }
    }

    //普通攻击
    public void normalAttack()
    {
        if (Mathf.Abs(hero.gameObject.transform.position.x - this.gameObject.transform.position.x) < attack_range &&
            Time.time - attack_start > attack_CD)
        {
            attack_start = Time.time;
            //hero.setHp(hero.getHp() - Monster_att * attack_value);
            if (id == 13 && skill_hit_on)
            {
                hit();
            }

			animator.SetBool ("Idle", false);
			animator.SetFloat ("die", 0.0f);
			animator.SetFloat ("hurt", 0.0f);
			if (id == 12) {
				animator.SetFloat ("attack", 1.0f);
			}
			if (id == 13) {
				animator.SetFloat ("attack", 1.0f);
				animator.SetFloat ("buff", 0.0f);
			}
            //Debug.Log("hero hp:" + hero.getHp());
        }
    }

    //被动技能
    public void skill_passive()
    {
		enemy.atk = Convert.ToInt32(enemy.atk * skill_passive_value);
    }

    //百分比伤害
    public void hit()
    {
        skill_hit_count++;
        //hero.setHp(hero.getHp() - hero.getHp_max() * skill_hit_value);
    }
}

