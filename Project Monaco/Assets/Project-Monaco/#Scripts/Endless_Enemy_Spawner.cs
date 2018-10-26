using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless_Enemy_Spawner : MonoBehaviour {

	public Rigidbody[] enemyPatterns;

	float timeBetweenSpawn;

	public float startTimeBetweenSpawn;
	public float decreaseTime;
	public float minTime = 0.65f;

	void Update()
	{

	timeBetweenSpawn -= Time.deltaTime;
		if (startTimeBetweenSpawn > minTime)
		{
			startTimeBetweenSpawn -= decreaseTime*Time.deltaTime;
		}
		if (timeBetweenSpawn < 0)
		{
		Invoke("EnemySpewing",startTimeBetweenSpawn);
		timeBetweenSpawn = startTimeBetweenSpawn;
	   }
	}

	void EnemySpewing()
	{
		Rigidbody clone;
		int randomPattern = Random.Range (0, enemyPatterns.Length);
		clone = Instantiate (enemyPatterns[randomPattern], transform.position, transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward *3f);
	}
}
