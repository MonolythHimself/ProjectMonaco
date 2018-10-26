using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKill : MonoBehaviour 
{
	
	float currentHealthHolder;

	private ScreenShake shake;

	void Start()
	{
		shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<ScreenShake> ();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player")
		{
			shake.CamShake ();

			currentHealthHolder = other.gameObject.GetComponent<Health> ().currentHealth;			

			if (this.tag == "Enemy")
			{
				currentHealthHolder = currentHealthHolder - .5f;
			}
	
			if (this.tag == "Respawn")
			{
				currentHealthHolder = currentHealthHolder - 5f;
			}

			if (this.tag == "Finish")
			{
				other.gameObject.GetComponent<Health> ().Death ();	
			}

			if (this.GetComponent<AudioSource> () != null)
			{
				this.GetComponent<AudioSource> ().Play ();
			}

			Destroy (this.gameObject, .1f);
		}

		if (other.collider.tag == "Respawn"&& other.collider.tag != "Enemy")
		{
			other.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (20f, other.transform.position, 20f);
        	Destroy (other.gameObject, 3f);
			Destroy (this.gameObject, .1f);

			if (this.GetComponent<AudioSource> () != null)
			{
				this.GetComponent<AudioSource> ().Play ();
			}
		}

		if (other.collider.tag == "Shield")
		{
			GetComponent<Rigidbody> ().AddExplosionForce (5f, other.transform.position, 5f);
			Destroy (this.gameObject, 2f);
			other.gameObject.SetActive(false);

			if (this.GetComponent<AudioSource> () != null)
			{
				this.GetComponent<AudioSource> ().Play ();
			}
		}

		if (other.collider.tag!="Shield" && other.collider.tag != "Player" && other.collider.tag != "Respawn" && other.collider.tag != "Enemy")
		{
			if (this.GetComponent<AudioSource> () != null)
			{
				this.GetComponent<AudioSource> ().Play ();
			}
			Destroy (this.gameObject, .1f);
		}
	}
}
