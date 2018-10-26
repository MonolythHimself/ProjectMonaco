using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposablePrompt : MonoBehaviour 
{
	public GameObject prompt;

	void Update () 
	{
		if (prompt.activeSelf == true && Input.anyKey && FindObjectOfType<SceneWatch>().playerDead!=true&& FindObjectOfType<SpellSystem>().spelling!=true && FindObjectOfType<PauseScript4MapScreen>().paused!=true)
		{
			SelfDestruct ();
		}

		if (prompt.activeSelf == true && FindObjectOfType<SceneWatch>().playerDead!=true && FindObjectOfType<SpellSystem>().spelling!=true && FindObjectOfType<PauseScript4MapScreen>().paused!=true)
		{
			Time.timeScale=.4f;
		}
	}

	public void SelfDestruct()
	{
		prompt.SetActive (false);
		DestroyObject (this.gameObject,.5f);
	}
}
