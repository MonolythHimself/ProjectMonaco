using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWatcher : MonoBehaviour 
{

	public GameObject pauseMenu;
	public GameObject[] uiElements;

	void Update () 
	{

		if(pauseMenu != null)
		if (pauseMenu.activeSelf)
		{
				foreach (GameObject bar in uiElements)
			{
				bar.SetActive (false);
			}
		}
			else 	if (pauseMenu.activeSelf != true )
				{
				foreach (GameObject bar in uiElements)
					{
						bar.SetActive (true);
					}
				}
			}
	}

