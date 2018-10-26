using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour 
{

	PlayerControl playerCon;

	public bool grounded;

	SpellSystem forceShield;

	void Start () 
	{
		playerCon = GetComponent<PlayerControl> ();
		forceShield = GetComponent<SpellSystem> ();
	}
	

	void FixedUpdate () 
	{
		grounded = playerCon.characterController.isGrounded;

		if (grounded==true)
		{
			if (forceShield.lifeBar != null)
			{				
				forceShield.lifeBar.image.color = Color.green;
			}
		}
		else
		{
			if (forceShield.lifeBar != null)
			{
				forceShield.lifeBar.image.color = Color.yellow;
			}
		}
	}
}
