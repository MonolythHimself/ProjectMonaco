using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrack : MonoBehaviour 
{

	SoulKeeper player;

	public Transform player2D;

	void Start () 
	{
		player = FindObjectOfType<SoulKeeper> ();
	}

	void Update () 
	{
		if (player != null)
		{
			transform.LookAt (player.transform);
			transform.position += transform.forward * 100 * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform == player.transform)
		{
			//Add shield generation code here.
			if (other.gameObject.GetComponent<SoulKeeper> () != null)
			{
				other.gameObject.GetComponent<SoulKeeper> ().soulCount += 1;
			}

			Destroy(this.gameObject,0.1f);
		}
	}

}
