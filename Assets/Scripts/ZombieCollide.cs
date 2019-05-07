using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollide : MonoBehaviour {

    // Use this for initialization
    public bool dead = false;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            dead = true;
        }
        if (collision.gameObject.tag == "MainCharacter")
        {
            Character a = collision.gameObject.GetComponent<Character>();
            a.Hit();
        }
    }
}
