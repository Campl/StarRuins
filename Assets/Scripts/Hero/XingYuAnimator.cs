using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XingYuAnimator : MonoBehaviour {
	
	private Animator anim;
	private CharacterController chra;
	private bool jump = false;
	public HeroStatus hero;
    public HeroAttack atk;
	bool isCude = false;
	float currentTime;
	// Use this for initialization
	void Start () {
		chra = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
		anim.speed = 0.5f;
		anim.SetBool ("Stand", true);
		anim.SetBool ("Jump", false);
		anim.SetBool ("Walk", false);
		anim.SetBool ("StandAttack", false);
		anim.SetBool ("HeroDie", false);
		anim.SetBool ("Hurt", false);
		anim.SetBool ("JumpAttack", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //向左
		if (ETCInput.GetAxisPressedLeft ("Horizontal")) {
			anim.SetFloat ("Direction", 0);
		}
        //向右
		if (ETCInput.GetAxisPressedRight ("Horizontal")) {
			anim.SetFloat ("Direction", 1);
		}
        //行走
		if ((ETCInput.GetAxisPressedLeft ("Horizontal") || ETCInput.GetAxisPressedRight ("Horizontal")) && chra.isGrounded) {
			anim.SetBool ("Walk", true);
			anim.SetBool ("Jump", false);
			anim.SetBool ("Stand", false);
			anim.SetBool ("StandAttack", false);
			anim.SetBool ("Hurt", false);
			anim.SetBool ("JumpAttack", false);
		}
        //跳跃
		if (ETCInput.GetAxisPressedUp ("Vertical")) {
			jump = true;
		}
		if (jump) {
			anim.SetBool ("Jump", true);
			anim.SetBool ("Stand", false);
			anim.SetBool ("Walk", false);
			anim.SetBool ("StandAttack", false);
			anim.SetBool ("Hurt", false);
			anim.SetBool ("JumpAttack", false);
			if (ETCInput.GetButton ("attackButton") && !isCude) {
				isCude = true;
				currentTime = Time.time;
				anim.SetBool ("Stand", false);
				anim.SetBool ("Jump", false);
				anim.SetBool ("Walk", false);
				anim.SetBool ("StandAttack", false);
				anim.SetBool ("Hurt", false);
				anim.SetBool ("JumpAttack", true);
			}
		}
		if (chra.isGrounded) {
			jump = false;
		}
        //站立
		if (!ETCInput.GetAxisPressedLeft ("Horizontal") && !ETCInput.GetAxisPressedRight ("Horizontal") && chra.isGrounded) {
			anim.SetBool ("Stand", true);
			anim.SetBool ("Walk", false);
			anim.SetBool ("Jump", false);
			anim.SetBool ("StandAttack", false);
			anim.SetBool ("Hurt", false);
			anim.SetBool ("JumpAttack", false);
		}
        //受伤
		if (hero.Patk) {
            hero.Patk = false;
			anim.SetBool ("Hurt", true);
			anim.SetBool ("Stand", false);
			anim.SetBool ("Jump", false);
			anim.SetBool ("Walk", false);
			anim.SetBool ("StandAttack", false);
			anim.SetBool ("HeroDie", false);
			anim.SetBool ("JumpAttack", false);
		}
		if (ETCInput.GetButton ("attackButton") && !atk.ifattack) {
			//isCude = true;
			//currentTime = Time.time;
			anim.SetBool ("Stand", false);
			anim.SetBool ("Jump", false);
			anim.SetBool ("Walk", false);
			anim.SetBool ("StandAttack", true);
			anim.SetBool ("Hurt", false);
			anim.SetBool ("JumpAttack", false);
		}
		if (Time.time - currentTime > 1) {
			isCude = false;
		}
	}
}
