using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction : MonoBehaviour 
{
	public Transform camera;

	public Rigidbody charge;

	private ScreenShake shake;

	Transform blank;

	void Start()
	{
		camera = Camera.main.transform;
		shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<ScreenShake> ();
	}
		
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Respawn")
		{
			blank = other.transform;
			shake.CamShake ();
			Destroy (other.gameObject, 0.5f);

			other.gameObject.GetComponent<Rigidbody> ().AddExplosionForce(100f,other.transform.position,100f,100f,ForceMode.Impulse);
		
			if (other.gameObject.GetComponent<Rigidbody> () != null)
			{
				SpoilsSpawn (charges:1);
			}	
		}

		if (other.collider != null && this.tag=="ImpactType")
		{
			if (this.GetComponent<AudioSource> () != null)
			{
				this.GetComponent<AudioSource> ().Play ();
			}
		}

		if (other.transform.tag == "Enemy")
		{
			blank = other.transform;
			shake.CamShake ();
			FindObjectOfType<PlayerControl> ().gravity = 0f;

			if (other.gameObject.GetComponent<Rigidbody> () != null)
			{
				SpoilsSpawn (charges:3);
				Instantiate (FindObjectOfType<PlayerControl> ().enemyBloodParticles, transform.position, Quaternion.identity);
				other.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			}	
				Destroy (other.gameObject, .2f);
		}
	}

	void SpoilsSpawn(int charges)
	{
			Rigidbody clone;
			clone = Instantiate (charge, blank.position, blank.rotation);
			clone.velocity = transform.TransformDirection (Vector3.back*5f);
	}
}
