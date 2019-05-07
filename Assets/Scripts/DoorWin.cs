using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWin : MonoBehaviour {

    public AudioSource audioData;
    public AudioSource stopMusic;
    public int weit = 0;
    public bool wait = false;
    
    // Use this for initialization
    void Start () {
        stopMusic = GameObject.Find("MainSong").GetComponent<AudioSource>();
        audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(audioData.isPlaying)
        {
            wait = true;
        }
        else
        {
            wait = false;
        }
        if (weit>0 && wait ==false)
        {
            Debug.Log("carga ps");
            SceneManager.LoadScene("Winer");
        }
    }
    void Win()
    {
        weit ++;
        audioData.Play();
        stopMusic.Stop();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCharacter")
        {
            Character main = collision.gameObject.GetComponent<Character>();
            main.HideSprite();
            Win();
        }
    }
}
