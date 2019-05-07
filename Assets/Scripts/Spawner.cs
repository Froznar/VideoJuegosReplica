    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject zombie;
    BoxCollider2D mine;
    public float intervalo = 5.0f;
    private float time = 4.0f;
    private bool spawn = false;
    // Use this for initialization
    void Start () {
        mine = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
		if (time > intervalo)
        {
            spawn = true;
            time = 0;
        }
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter" && spawn == true)
        {            
            Vector3 Position = RandomPointInBounds(mine.bounds);
            Object.Instantiate(zombie, Position, Quaternion.identity);
            spawn = false;
        }
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

}
