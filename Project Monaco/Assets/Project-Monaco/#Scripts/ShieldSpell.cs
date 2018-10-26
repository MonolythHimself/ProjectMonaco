using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpell : MonoBehaviour
{

	Health health;

	public GameObject shield;

	void Start () 
	{
		health = GetComponent<Health> ();
	}

	void Update () 
	{
		if (shield.activeSelf)
		{
			this.tag = "Shield";
		}
		else if(shield.activeSelf==false)
		{
			this.tag = "Player";
		}
	}
}
