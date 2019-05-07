using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour {

    public Image full;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Nofull()
    {
        full.enabled = false;
    }
    public void Restore()
    {
        full.enabled = true;
    }
}
