using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampBar : MonoBehaviour {

	public Slider chargeBar;

	void Update () 
	{
		Vector3 barPosition = Camera.main.WorldToScreenPoint (this.transform.position);

		if (chargeBar != null)
		{
			chargeBar.transform.position = barPosition;
		}
		
	}
}
