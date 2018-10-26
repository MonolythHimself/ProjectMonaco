using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseScript4MapScreen : MonoBehaviour 
{

	public SpellSystem spling;

	public bool paused;

	public bool soundConfig;

	public bool configGFX;

	public bool quitScreenActive;

	public GameObject pauseMenu;

	public GameObject soundMenu;

	public GameObject graphicsMenu;

	public GameObject quitScreen;

	public GameObject mapPanel;

	GameObject socialsPanel;

	public AudioSource music;

	void Start () 
	{
		spling = FindObjectOfType<SpellSystem> ();

		soundConfig = false;
		configGFX = false;
		quitScreenActive = false;

		if (pauseMenu != null)
		{
			pauseMenu.SetActive (false);
		}
	}

	void Update ()
	{
		if (CrossPlatformInputManager.GetButtonDown ("Pause"))
		{
			paused = !paused;
		}

		if (paused && !soundConfig&& !configGFX&& !quitScreenActive)
		{
			Pause ();
		}

		if (!paused && soundConfig&& !configGFX&& !quitScreenActive)
		{
			SoundConfig ();
		}

		if (!paused && !soundConfig&& configGFX&& !quitScreenActive)
		{
			GFX ();
		}

		if (!paused && !soundConfig&& !configGFX&& quitScreenActive)
		{
			quitScreenActivecreen ();
		}
		else if (!paused && !soundConfig&& !configGFX&& !quitScreenActive)
		{
				Resume ();
		}
	}

	public void Pause()
	{
		if (paused == false)
		{
			paused = true;
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
			mapPanel.SetActive (false);
		}
	
		if (music != null)
		{
			music.Pause ();
		}

		if (configGFX == true)
		{
			configGFX = false;
			if (graphicsMenu.activeSelf)
			{
				graphicsMenu.SetActive (false);
			}
		}

		if (soundConfig == true)
		{
			soundConfig = false;
			if (soundMenu.activeSelf)
			{
				soundMenu.SetActive (false);
			}
		}

		if (quitScreenActive == true)
		{
			quitScreenActive = false;
			if (quitScreen.activeSelf)
			{
				quitScreen.SetActive (false);
			}
		}
	}
		
	public void Resume()
	{
		if (music != null)
		{
			music.UnPause ();
		}

			if (spling != null && spling.spelling != true && FindObjectOfType<DisposablePrompt>() ==null)
			{
				Time.timeScale = 1;
			}
		
		mapPanel.SetActive (true);

		if (paused == true)
		{
			paused = false;
			if (pauseMenu != null)
			{
				pauseMenu.SetActive (false);
			}
		}

		if (configGFX == true)
		{
			configGFX = false;
			if (graphicsMenu.activeSelf)
			{
				graphicsMenu.SetActive (false);
			}
		}

		if (soundConfig == true)
		{
			soundConfig = false;
			if (soundMenu.activeSelf)
			{
				soundMenu.SetActive (false);
			}
		}

		if (quitScreenActive == true)
		{
			quitScreenActive = false;	
			if (quitScreen.activeSelf)
			{
				quitScreen.SetActive (false);
			}
		}
	}
		
	public void MainMenu(int index)
	{
		SceneManager.LoadScene (index);
	}
		
	public void quitScreenActivecreen()
	{
		if (quitScreenActive != true)
		{
			quitScreenActive = true;
			Time.timeScale = 0;
			quitScreen.SetActive (true);
			mapPanel.SetActive (false);
			pauseMenu.SetActive (false);
		}

		if (paused == true)
		{
			paused = false;
		}

		if (configGFX == true)
		{
			configGFX = false;
		}

		if (soundConfig == true)
		{
			soundConfig = false;
		}
	}

	public void SoundConfig()
	{
		Time.timeScale = 0;

		if (soundConfig == false)
		{
			soundConfig = true;
			Time.timeScale = 0;
			soundMenu.SetActive (true);
			mapPanel.SetActive (false);
			pauseMenu.SetActive (false);
		}

		if (paused == true)
		{
			paused = false;
		}

		if (configGFX == true)
		{
			configGFX = false;
		}

		if (quitScreenActive == true)
		{
			quitScreenActive = false;
		}
	}

	public void GFX()
	{
		Time.timeScale = 0;

		if (configGFX == false)
		{
			configGFX = true;
			Time.timeScale = 0;
			graphicsMenu.SetActive (true);
			mapPanel.SetActive (false);
			pauseMenu.SetActive (false);
		}

		if (paused == true)
		{
			paused = false;
		}

		if (soundConfig == true)
		{
			soundConfig = false;
		}

		if (quitScreenActive == true)
		{
			quitScreenActive = false;
		}
	}

	public void Quit()
	{
		Application.Quit ();
	}
}




