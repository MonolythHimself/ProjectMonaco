using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingObject : MonoBehaviour 
{
	public Color bass;

	void Update ()
	{
		Material mat = this.GetComponent<Renderer> ().material;
		float emission = Mathf.PingPong (Time.time, .05f);
		Color baseColor = bass; 
		//Replace this with whatever you want for your base color at emission level '1'
		Color finalColor = baseColor* Mathf.LinearToGammaSpace (emission);
		mat.SetColor ("_EmissionColor", finalColor);	
	}
}
