using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseScript : MonoBehaviour 
{
	
	public bool paused;

	public GameObject pauseMenu;

	SceneWatch restart;

	DisposablePrompt disposablePrompt;

	void Start () 
	{
		disposablePrompt = FindObjectOfType<DisposablePrompt> ();

		paused = false;

		pauseMenu.SetActive(false);
	}

	void Update ()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Pause"))
		{
			paused = !paused;
		}

		if (paused)
		{
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
		}
		else if (!paused)
		{
			if (FindObjectOfType<DisposablePrompt> () != null ^ FindObjectOfType<SpellSystem> ().spelling != true )
				{
					Resume ();
				}
	    }
	}

	public void Resume()
	{
		paused = false;
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene (1);
	}

	public void Sound()
	{
		//PlayerPrefs.SetInt ("currentscenesave", SceneManager.LoadScene(0));
	}

	public void GFX()
	{
		//SceneManager.LoadScene (PlayerPrefs.GetInt ("currentscenesave"));
	}

	public void Quit()
	{
		Application.Quit ();
	}
}

	

