using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

	public float health;

	public float currentHealth;

	public Text livesText;

	Transform[] parts;

	void Start () 
	{
		currentHealth = health;
	}

	void Update () 
	{
		if (livesText != null)
		{
			livesText.text = "Lives, " + currentHealth;
		}

		if (currentHealth <= 0)
		{
			currentHealth = 0f;
		}
		
		if (currentHealth == 0)
		{
			Death ();
		}

		if (this.gameObject.tag == "Player" && currentHealth==0f)
		{
			Death ();
		}
	}

	public void Death()
	{
		this.gameObject.GetComponent<MeshRenderer>().material.color=Color.red;
		this.gameObject.AddComponent<Rigidbody> ();
		this.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (20f, this.transform.position, 20f);
		parts=this.gameObject.GetComponentsInChildren<Transform> ();
		this.gameObject.AddComponent<FlashingObject> ();
		this.gameObject.GetComponent<AudioSource> ().Play();

		if (this.gameObject.GetComponent<PlayerControl> () != null)
		{
			this.gameObject.GetComponent<PlayerControl> ().enabled = false;
			Instantiate (GetComponent<PlayerControl> ().playerBloodParticles, transform.position, Quaternion.identity);
		}
			
		foreach (Transform obj in parts)
		{
			obj.parent = null;
			obj.gameObject.AddComponent<Rigidbody> ();
			obj.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (20f, transform.position, 20f);
		}
	}
}
