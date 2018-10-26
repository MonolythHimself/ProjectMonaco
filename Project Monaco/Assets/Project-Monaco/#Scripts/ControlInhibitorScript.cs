using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInhibitorScript : MonoBehaviour 
{

	GameObject playerObject;

	public bool cantMoveRight;

	public bool canMoveOmni;

	public bool cantJump;

	void Start () 
	{
		playerObject = GameObject.Find("Player Humanoid");
	}

	void Update () 
	{
		if (playerObject.GetComponent<PlayerControl> () != null)
		{
			playerObject.GetComponent<PlayerControl> ().canSteer = false;
		}

		if (cantMoveRight)
		{
			if (playerObject.GetComponent<PlayerControl> () != null)
			{
				playerObject.GetComponent<PlayerControl> ().inputFloat = 1f;
			}
		}

		if (canMoveOmni)
		{
		cantMoveRight = false;
		
		cantJump = false;

			if (playerObject.GetComponent<PlayerControl> () != null)
			{
				playerObject.GetComponent<PlayerControl> ().initialSpeed = playerObject.GetComponent<PlayerControl> ().speed;
			}
		}

		if (cantJump)
		{
			if (playerObject.GetComponent<PlayerControl> () != null)
			{
				playerObject.GetComponent<PlayerControl> ().jumpage = 0f;	
			}	
		}
	}
}
