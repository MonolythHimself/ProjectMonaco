using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour 
{

	public string boolName;

	public Animator builtInAnimator;

	public float animationSpeed;

	void Start () 
	{
		builtInAnimator = GetComponent<Animator> ();
	}

	void Update () 
	{
		if (builtInAnimator != null)
		{
			builtInAnimator.SetBool (boolName, true);
		}
		
		builtInAnimator.speed = animationSpeed;
		
	}
}
