using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour {

	public Rigidbody enemies;

	public int enemyCount;

	public int i = 0; 

	public float countDownTimeBetweenShots = .5f;

   float timer;

	public void FixedUpdate()
	{
		timer += Time.deltaTime;
		if (i < enemyCount && timer >= countDownTimeBetweenShots)
		{
			Invoke ("Spit", countDownTimeBetweenShots);
			timer = 0f;
			i += 1;
		}

		if (i== enemyCount)
		{
			this.enabled = false;

		}

	}
	void Spit () 
	{
			Rigidbody clone;
			clone = Instantiate (enemies, transform.position, transform.rotation);
			clone.velocity = transform.TransformDirection (Vector3.forward);
		
	}
}
