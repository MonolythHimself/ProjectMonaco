using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	
	public void Start_Game()
	{
		SceneManager.LoadScene (1);
	}

	public void Quit_Game()
	{
		Application.Quit();
	}
}
