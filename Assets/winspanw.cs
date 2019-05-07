using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winspanw : MonoBehaviour {

    public GameObject porrista;
    public GameObject bb;
    public GameObject dog;
    public GameObject meat;
    public GameObject psisina;
    public GameObject turista;
    public GameObject vieja;
    public Data data;
    public bool done = false;
    public float timer;
    public int cont = 0;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if(done == false && timer > 2)
        {
            Vector3 asd = new Vector3(1.8f, 0, 0);
            if(cont == 0)
            {
                Object.Instantiate(porrista, transform.position + (asd*(cont+1)), Quaternion.identity);
            }
            if (cont == 1)
            {
                Object.Instantiate(vieja, transform.position + (asd * (cont + 1)), Quaternion.identity);
            }
            if (cont == 2)
            {
                Object.Instantiate(meat, transform.position + (asd * (cont + 1)), Quaternion.identity);
            }
            if (cont == 3)
            {
                Object.Instantiate(bb, transform.position + (asd * (cont + 1)), Quaternion.identity);
            }
            if (cont ==4)
            {
                Object.Instantiate(turista, transform.position + (asd * (cont + 1)), Quaternion.identity);
            }
            if (cont == 5)
            {
                Object.Instantiate(dog, transform.position + (asd * (cont + 1)), Quaternion.identity);
            }
            if (cont == 6)
            {
                Object.Instantiate(psisina, transform.position + (asd * (cont + 1)), Quaternion.identity);
            }
            cont++;
            timer = 0;
        }
        if(cont >= 7)
        {
            done = true;
        }
        
	}
    
}
