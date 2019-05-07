using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePosition : MonoBehaviour {

    private SpriteRenderer[] SprRender;
	// Use this for initialization
	void Start () {
              
	}
	
	// Update is called once per frame
	void Update () {
        SprRender = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer renderer in SprRender)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
        }
	}
}
