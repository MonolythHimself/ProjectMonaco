using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpitter : MonoBehaviour 
{

	ParticleSystem targetParticle;

	void Start () 
	{
		targetParticle=GetComponent<ParticleSystem> ();
		targetParticle.gameObject.SetActive (false);
	}
	
	public void HitMe(Vector3 hitPoint)
	{
		targetParticle.gameObject.SetActive (true);
		targetParticle.transform.position = hitPoint;
		targetParticle.Play ();
	}
}
