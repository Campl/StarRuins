using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {
    public Transform player;
    public Transform Ccamera;
    private int battle;
	// Use this for initialization
	void Start () {
        battle = PlayerPrefs.GetInt("Battle");
        
        switch (battle)
        {
            case 1:
                player.position = new Vector3(-23,-0.27f,0);
                Ccamera.position = new Vector3(-19, -0.27f, 0);
                break;
            case 2:
                player.position = new Vector3(-23, -16.15f, 0);
                Ccamera.position = new Vector3(-18, -16.15f, 0);
                break;
            case 3:
                player.position = new Vector3(-23, -29.2f, 0);
                Ccamera.position = new Vector3(-18, -29.2f, 0);
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
