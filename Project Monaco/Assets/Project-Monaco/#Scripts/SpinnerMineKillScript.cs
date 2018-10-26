using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerMineKillScript : MonoBehaviour 
{

	private ScreenShake shake;

	void Start()
	{
		shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<ScreenShake> ();
	}

	void Update()
	{
			Destroy (this.gameObject, 8f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && other.GetComponent<Health> () != null)
		{
			shake.CamShake ();
			other.gameObject.GetComponent<Health> ().currentHealth -= 1f;
		
			if (other.gameObject.GetComponent<PlayerControl> () != null)
			{
				Instantiate (other.gameObject.GetComponent<PlayerControl> ().playerBloodParticles, transform.position, Quaternion.identity);
	       	}
				Destroy (gameObject);
		}

		if (other.GetComponent<Collider>().tag == "Respawn" && other.GetComponent<Collider>().tag != "Enemy")
		{
			Destroy (other.gameObject, 3f);
		}

		if (other.GetComponent<Collider>().tag == "Shield")
		{
			shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<ScreenShake> ();
			Destroy (this.gameObject);
			this.GetComponent<Rigidbody> ().AddExplosionForce (10f, transform.position, 10f);
		}
	}
}
