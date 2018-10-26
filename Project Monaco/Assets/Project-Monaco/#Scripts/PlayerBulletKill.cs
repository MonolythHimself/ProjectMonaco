using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletKill : MonoBehaviour 
{

	public Rigidbody soulPointObject;

	private ScreenShake camShake;

	public Transform blank;

	void Start()
	{
		camShake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<ScreenShake> ();
	}

	void Update()
	{
		Destroy (this.gameObject, 5f);	
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Enemy")
		{
			blank = other.transform;

			if (other.gameObject.GetComponent<SpinerMine> () != null)
			{
				other.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (20f, other.transform.position, 20f);

				if (FindObjectOfType<PlayerControl> () != null)
				{
					Instantiate (FindObjectOfType<PlayerControl> ().enemyBloodParticles, transform.position, Quaternion.identity);
				}

				if (FindObjectOfType<PlayerControl> () != null)
				{
					Instantiate (FindObjectOfType<PlayerControl> ().enemyBloodParticles, transform.position, Quaternion.identity);
				}

				if (FindObjectOfType<PlayerControl> () != null)
				{
					Instantiate (FindObjectOfType<PlayerControl> ().enemyBloodParticles, transform.position, Quaternion.identity);
				}

				other.gameObject.GetComponent<SpinerMine> ().enabled = false;

                other.gameObject.AddComponent<MeshRenderer> ();
				other.gameObject.GetComponent<MeshRenderer> ().material.color = Color.black;

				Destroy (other.gameObject, .5f);
			}
			

			if (other.gameObject.GetComponent<ShooterMine> () != null)
			{
					if (FindObjectOfType<PlayerControl> () != null)
					{
						Instantiate (FindObjectOfType<PlayerControl> ().enemyBloodParticles, transform.position, Quaternion.identity);
					}

		    	other.gameObject.GetComponent<ShooterMine> ().enabled = false;
				other.gameObject.GetComponent<MeshRenderer> ().material.color = Color.black;
				other.gameObject.AddComponent<Rigidbody> ();

                Destroy (other.gameObject, 1f);
			}

			if (other.gameObject.GetComponent<Rigidbody> () != null)
			{
			other.gameObject.AddComponent<Rigidbody> ();
				SoulPointSpawn (3);
			}	

			Destroy (other.gameObject, 1f);
			Destroy (this.gameObject, .1f);
		}

		if (other.collider.tag == "Respawn")
		{
			blank = other.transform;
			Destroy (other.gameObject, 3f);
			Destroy (this.gameObject, .1f);

			if (other.gameObject.GetComponent<Rigidbody> () != null)
			{
				SoulPointSpawn (1);
			}	
		}

		if (other.collider.tag == "Shield")
		{
			Destroy (this.gameObject, 5f);
		}

		if (other.collider.tag!="Shield" && other.collider.tag != "Player" && other.collider.tag != "Respawn" && other.collider.tag != "Enemy")
		{
			Destroy (this.gameObject, .1f);
		}
	}

	void SoulPointSpawn(int points)
	{
		for (int i = 0; i < points; i++)
		{
			Rigidbody clone;
			clone = Instantiate (soulPointObject, blank.position, blank.rotation);
			clone.velocity = transform.TransformDirection (Vector3.back*5f);
			this.enabled = false;
		}
	}
}
