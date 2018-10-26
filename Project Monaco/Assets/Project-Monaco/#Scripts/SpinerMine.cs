using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinerMine : MonoBehaviour 
{

	public float attackSpeed;

	GameObject player;

	float playerDist;

	public string playerTag;

	Transform blank;

	void Start()
	{
		player = GameObject.Find ("Player Humanoid");
	}

	void Update () 
	{
		Destroy (gameObject, 8f);
			
		if(player!=null)
		{
				playerDist = Vector3.Distance (player.transform.position, transform.position);
		}
		
	   transform.position+=transform.forward*(attackSpeed*.75f)*Time.deltaTime;

		if(player!=null)
		if (playerDist <= 10f)
		{
			GetComponentInChildren<SpinerKill> ().rotatorXAxisSpeed = 5f;
				this.gameObject.AddComponent<SpinnerMineKillScript> ();
				transform.position += transform.forward * (attackSpeed*.85f) * Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Health> ().currentHealth -= 1f;
			this.GetComponent<MeshCollider> ().enabled = false;
	     	Instantiate (other.gameObject.GetComponent<PlayerControl> ().playerBloodParticles, transform.position, Quaternion.identity);
		}
	}
}
