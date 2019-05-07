using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectChar : MonoBehaviour {

    public AudioSource audioData;
    public int weit = 0;
    public bool wait = false;
    // Use this for initialization
    void Start()
    {
        audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (audioData.isPlaying)
        {
            wait = true;
        }
        else
        {
            wait = false;
        }
        if (weit > 0 && wait == false)
        {
            SceneManager.LoadScene("Level1");
            Debug.Log("Enter key is pressed.");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            weit++;
            audioData.Play();
        }
    }
}
