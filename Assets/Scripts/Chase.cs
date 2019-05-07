using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public bool contact;
	// Use this for initialization
	void Start () {
        contact = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter")
        {
            contact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter")
        {
            contact = false;
        }
    }
}
