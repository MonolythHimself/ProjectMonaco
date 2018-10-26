using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMine : MonoBehaviour 
{

	public float attackSpeed;

	Transform player;

	float playerDistance;

	PistolSpell[] pistolSpell;

	bool friendlyFire;

	void Start () 
	{
		player = GameObject.Find ("Player Humanoid").transform;
		pistolSpell = GetComponentsInChildren<PistolSpell> ();

		friendlyFire = true;
	}

	void Update () 
	{
		if (player != null)
		{
			playerDistance = Vector3.Distance (player.position, transform.position);
		}

		if(playerDistance <= 100f && friendlyFire)
		{
			Destroy (gameObject, 8f);
			transform.LookAt (this.transform.forward);
		}
		else
		{
			transform.position.Set (transform.position.x, transform.position.y, 0f);
			transform.rotation.Set (0f, 0f, 0f, 0f);
		   transform.position += transform.forward * attackSpeed * Time.deltaTime;
        	attackSpeed = 10f;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Health> ().currentHealth -= 1f;
			this.GetComponent<MeshCollider> ().enabled = false;
			Instantiate (other.gameObject.GetComponent<PlayerControl> ().playerBloodParticles, transform.position, Quaternion.identity);
		}
	}
}
