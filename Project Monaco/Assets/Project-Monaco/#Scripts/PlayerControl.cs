using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour 
{
	
	//These are 'blood' particles of the player and enemies.
	//They're mainly used by other scripts attached to bullets and blades.
	public GameObject playerBloodParticles;
	public GameObject enemyBloodParticles; 

	//Movement variables
	[HideInInspector]
	public float inputFloat;
	public float gravity;
	public bool onground;
	public float initialGravity;
	public float initialSpeed;
	public float speed;
	public float jumpage;
	public float initialJump;
	//These two below are meant to gradually increase player speed endless runner style.
	public float accelerationAmount = 0.05f;
	public float maximumSpeedTime = 15f;
	Vector3 playerDirection;
	[HideInInspector]
	public Vector3 playerVelocity;
	//These deal with movement controls and are there for the Inhibitor script.
	bool steered;
	[HideInInspector]
	public bool canSteer;

	[HideInInspector]
	public CharacterController characterController;

	//This layer Mask is used for ground detection, useful when implimenting jump mechanics
	public LayerMask groundLayer;

	void Start()
	{
		groundLayer = LayerMask.GetMask ("Ground");
		characterController = GetComponent<CharacterController> ();
	
		speed = initialSpeed;
		initialJump = jumpage;

		steered = true;
		canSteer = true;
	}

	void FixedUpdate()
	{
		//The CheckSphere is more reliable than directly using the character Controller, especially at high speed.
		onground = Physics.CheckSphere(transform.GetChild(0).position, 1f, groundLayer, QueryTriggerInteraction.Ignore);
	}
		
	void Update()
	{			
		characterController.Move(playerVelocity * Time.deltaTime);

		Steer ();
		Jump ();

		//No more side to side problems, setting local position by hand keeps the player from falling sideways off a level.
		if (transform.position.z != 0f)
		{
			transform.localPosition.Set (transform.position.x, transform.position.y, 0f);
		}

		characterController.Move (playerDirection * Time.deltaTime);

		playerDirection = new Vector3 (playerVelocity.x,0,0f);

		//This locks the movement vector of 3d objects so that they move side to side like 2d characters.
		if (playerDirection != Vector3.zero)
		{
			transform.right = playerDirection;
		}
	
		//these are the gradual speed increasers.
			if (speed < maximumSpeedTime)
			{
			speed += accelerationAmount*Time.deltaTime;
			}

		if (speed >= maximumSpeedTime)
		{
			speed = initialSpeed;
		}
			
		//This is for player steering controls and for now just keeps the player going right.
		if (steered)
		{
			inputFloat = 1f;
			//Input.GetAxis ("Horizontal")* speed;
		}
		else
		{
			inputFloat = -1f;
		}
	}
		
	//The steer method below contains dormant movement controls.
	void Steer()
	{
		if (inputFloat >=1f)
		{
			playerVelocity.x =  (speed*15)*Time.deltaTime;
		}

		if (inputFloat <= -1f)
		{
			playerVelocity.x = (-speed*15)*Time.deltaTime ;
		}
	}

	//The jump mechanic below allows for the use of many different keys for player convenience.
	void Jump()
	{
		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetButtonDown ("Up")) && onground==true)
		{
			playerVelocity.y = jumpage;
		}
		else
		{
			playerVelocity.y -= gravity* Time.deltaTime;
		}
	}
}
