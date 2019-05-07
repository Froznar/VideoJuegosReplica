using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter")
        {
            Character a = collision.gameObject.GetComponent<Character>();
            a.neighbours--;
            a.neighboursGet++;
            Destroy(gameObject);
        }
    }
}
