using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour 
{

	public Rigidbody bullet;

	public AudioSource shotFired;

	public float bulletSpeed;

	public float countDownTimeBetweenShots = .5f;

	public float timer;

	void Start () 
	{
		shotFired = GetComponent<AudioSource> ();
	}

	public void Update()
	{

		timer += Time.deltaTime;
		if (timer >= countDownTimeBetweenShots)
		{
			Invoke ("FireNow",countDownTimeBetweenShots);
			timer = 0f;
		}
	}

	public void FireNow()
	{

		if (shotFired != null)
		{
			shotFired.Play ();
		}

		Rigidbody clone;
		clone = Instantiate (bullet, transform.position, transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward * bulletSpeed);
	}
}
