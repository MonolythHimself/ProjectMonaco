using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour 
{

	public Transform levelBlock;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name== "Player Humanoid")
		{
			Instantiate (levelBlock, this.transform.position, Quaternion.identity);
		}
	}
}
