using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public float lifetime;
	void Start () {
        Invoke("DestroyProyectile", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.right * speed * Time.deltaTime);
	}

    void DestroyProyectile()
    {        
        Destroy(gameObject);
    }
}
