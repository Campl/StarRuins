using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroStatus : MonoBehaviour {
    public CalculateAttribute cal;
    public EnemyStatus ens;
    public Attack attack;
    public bool Patk=false;

                                       // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        if (CurrentAttribute.hp <= 0)
            SceneManager.LoadScene("scene4");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyHit")
        {
            CurrentAttribute.hp -= attack.Damage(ens.atk, CurrentAttribute.def, ens.crirRate, ens.crirRatio);
            Patk = true;
        }
    }
}
