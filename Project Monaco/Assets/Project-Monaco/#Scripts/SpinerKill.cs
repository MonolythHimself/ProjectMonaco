using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinerKill : MonoBehaviour {

	public float rotatorZAxisSpeed;
	public float rotatorXAxisSpeed;
	public float rotatorYAxisSpeed;

	void Update () 
	{
		transform.Rotate (new Vector3 (rotatorXAxisSpeed,rotatorYAxisSpeed,rotatorZAxisSpeed)*10f);
	}
}
