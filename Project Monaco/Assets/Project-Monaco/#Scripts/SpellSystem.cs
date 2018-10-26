using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class SpellSystem : MonoBehaviour 
{

	public GameObject spellMenu;

	public Slider lifeBar;

	public bool spelling;

	DisposablePrompt disposablePrompt;

	float timer;

	PauseScript4MapScreen paus;


	void Start()
	{
		paus = FindObjectOfType<PauseScript4MapScreen> ();

		disposablePrompt=FindObjectOfType<DisposablePrompt> ();

		spellMenu.SetActive (false);
	}

	void Update()
	{

		if (CrossPlatformInputManager.GetButtonDown ("Fire2") && spelling ==false)
		{
			spellMenu.SetActive (true);
			spelling = true;
			spellMenu.transform.position = Input.mousePosition;

			if (GetComponent<PlayerControl> () != null)
			{
				GetComponent<PlayerControl> ().canSteer = false;
			}
			Time.timeScale = .2f;
		}

		else if (CrossPlatformInputManager.GetButtonUp ("Fire2") && spelling==true)
			{ 
				if (GetComponent<PlayerControl> () != null)
				{
					GetComponent<PlayerControl> ().canSteer = true;
				}

				Time.timeScale = 1f;
				spelling = false;
				spellMenu.SetActive (false);
			}
	}
}


