using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSpell : MonoBehaviour 
{

	public Rigidbody bullet;

	public AudioSource shotSound;

	public float bulletSpeed;

	public bool canFire;

	public float countDownTimeBetweenShots = .5f;

	public float timer;

	private ScreenShake camShake;

	void Awake () 
	{
		shotSound = GetComponent<AudioSource> ();
		camShake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponentInChildren<ScreenShake> ();
		canFire = true;
		timer = 0f;
	}

	public void Update()
	{

		timer += Time.deltaTime;
		if (canFire == true && timer >= countDownTimeBetweenShots)
		{
			canFire = false;
			FireNow ();
			//camShake.CamShake ();
			timer = 0f;
		}
	}

	public void FireNow()
	{
		if (shotSound != null)
		{
			shotSound.Play ();
		}
	


		Rigidbody clone;
		clone = Instantiate (bullet, transform.position, transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward * bulletSpeed);
		canFire = true;
	} 
}
