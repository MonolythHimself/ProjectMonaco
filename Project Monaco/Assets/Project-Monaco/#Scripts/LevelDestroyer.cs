using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour 
{
	public GameObject levelDestroyer;

	void Start()
	{
		levelDestroyer = GameObject.Find ("Killing platforms");

	}

	void Update()
	{
		if (transform.position.x < levelDestroyer.transform.position.x)
		{
			Destroy (gameObject);
		}
	}

}
