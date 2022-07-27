using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
	
	public GameObject player;
	private Animator anim;
	private Rigidbody2D rb;
	[SerializeField] private AudioSource DeathSoundAffect;
	[SerializeField] private AudioSource bgm;

	private  void Start()
    {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("trap"))
		{
			
			Die();
			
		}
	}
	 
	public void Die()
	{
		DeathSoundAffect.Play();
	    anim.SetTrigger("deaths"); //death animation play
		rb.bodyType = RigidbodyType2D.Static;
		Invoke("RestartLevel", 1f);  //call restart level function after 1s delay	


	}

	 private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);	
	}
	
	

}
