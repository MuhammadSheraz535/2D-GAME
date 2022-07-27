using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    private AudioSource FinishSound;
    private bool levelCompleted = false;
    private void Start()
    {
        FinishSound = GetComponent<AudioSource>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" && !levelCompleted)
        {
            FinishSound.Play();
             levelCompleted = true;
            Invoke("CompleteLevel", 1f);  //next level call after delay for 1 second
        }
    }

    private void CompleteLevel()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        
	}

}
