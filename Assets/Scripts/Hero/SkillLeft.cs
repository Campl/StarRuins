using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLeft : MonoBehaviour {
	Rigidbody rigid;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		rigid.velocity = new Vector3 (-speed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
