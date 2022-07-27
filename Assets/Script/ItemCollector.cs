using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
	private int count = 0;

	[SerializeField] private Text cherriesText;
	[SerializeField] private AudioSource CollectSoundAffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Cherry"))
		{
			CollectSoundAffect.Play();
			Destroy(collision.gameObject);
			count = count + 5;
			cherriesText.text = "Score :" + count;
			
		}
	}
}
