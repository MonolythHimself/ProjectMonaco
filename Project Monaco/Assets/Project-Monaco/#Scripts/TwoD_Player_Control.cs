using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TwoD_Player_Control : MonoBehaviour {


	Rigidbody2D rb;
	public float speed;
	float moveInput;


	public bool onground;
	public Transform feetPos;
	public float checkRadius;
	public LayerMask whatIsGround;

	public float jumpCounter;
	public float jumpTime;
	public bool isJumping;

	public float jumpage;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	   jumpCounter = jumpTime;
	}
	
	void FixedUpdate()
	{

	}

	void Update ()
	{
		moveInput = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

		onground = Physics2D.OverlapCircle (feetPos.position, checkRadius, whatIsGround);

			if (moveInput > 0)
		{
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		else if(moveInput < 0)
		{
			transform.eulerAngles = new Vector3 (0, 180, 0);
		}

		if (onground==true&& Input.GetKeyDown (KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			isJumping = true;
			rb.velocity = Vector2.up * jumpage;
			jumpCounter = jumpTime;

		}

		if (Input.GetKey (KeyCode.UpArrow) || CrossPlatformInputManager.GetButton ("Jump") && isJumping==true)
		{
			if (jumpCounter > 0)
			{
				rb.velocity = Vector2.up * jumpage;
				jumpCounter -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}
				}

		if (Input.GetKeyUp(KeyCode.UpArrow) || CrossPlatformInputManager.GetButtonUp ("Jump"))
		{
			isJumping = false;
		}
	}
}
