using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack : MonoBehaviour { 
    float damage;
    public Rigidbody bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     public float Damage(int Atk, int Tardef,float Critchance, float Critdamage)
    {
        int rand = Random.Range(0, 99);
        if (rand < Critchance)
            damage = (Atk - Tardef) * Critdamage;
        else
            damage = Atk - Tardef;
        return damage;     
    }
}
