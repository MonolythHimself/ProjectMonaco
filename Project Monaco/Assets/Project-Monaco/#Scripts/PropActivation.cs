using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropActivation : MonoBehaviour 
{
	public GameObject[] spawnableProps;

	Transform player;

	public float spawnTriggerDistance;

	public float playerDistance;

	void Start () 
	{
		if (player != null)
		{
			player = GameObject.FindGameObjectWithTag ("Player").transform;
		}

		foreach (GameObject prop in spawnableProps)
		{
			if (prop != null)
			{
				prop.SetActive (false);
			}	
		}
	}

	void Update()
	{
		if (playerDistance <= spawnTriggerDistance)
		{
			Destroy (this.gameObject, 3f);

			foreach (GameObject prop in spawnableProps)
			{
				if (prop != null)
				{
					prop.SetActive (true);
				}
			}
		}

		if (GetComponent<SphereCollider> () != null)
		{
			GetComponent<SphereCollider> ().radius = spawnTriggerDistance;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy (this.gameObject, 3f);

			foreach (GameObject prop in spawnableProps)
			{
				prop.SetActive (true);
			}
		}
	}
}
