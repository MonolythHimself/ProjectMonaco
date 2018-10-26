using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSpell : MonoBehaviour 
{
	
	GameObject playerObject;

	public float xAxisIncriment = 1.5f;
	public float maxIncriment = 80f;

	float temporarySpeedValueHolder;

	void Start () 
	{
		playerObject = GameObject.Find ("Player Humanoid");

		if (playerObject.GetComponent<PlayerControl> () != null)
		{
			temporarySpeedValueHolder =	playerObject.GetComponent<PlayerControl> ().initialSpeed;
		}
	}

	void Update () 
	{
		if (playerObject.transform.localPosition.x >= maxIncriment)
		{
			if (playerObject.GetComponent<PlayerControl> () != null)
			{
				playerObject.transform.position.Set (playerObject.GetComponent<PlayerControl> ().playerVelocity.x, 0f, 0f);
				playerObject.GetComponent<PlayerControl> ().playerVelocity.x = playerObject.GetComponent<PlayerControl> ().initialSpeed * xAxisIncriment;
			}
		}
		else
		{
			if (playerObject.GetComponent<PlayerControl> () != null)
			{
				playerObject.transform.position.Set (playerObject.GetComponent<PlayerControl> ().playerVelocity.x, playerObject.GetComponent<PlayerControl> ().playerVelocity.y, 0f);
				playerObject.GetComponent<PlayerControl> ().speed = temporarySpeedValueHolder;
			}
		}
	}
}
