﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animCtrl : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.speed = 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
