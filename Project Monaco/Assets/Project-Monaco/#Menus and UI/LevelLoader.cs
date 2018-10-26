using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour 
{

	public GameObject loadingScreen;

	public Slider loadingBar;

	public GameObject prevMenu;

	void Start()
	{
		if (loadingScreen.activeSelf)
		{
			loadingScreen.SetActive (false);
		}
		
	}
	public void LoadLevel (int sceneIndex)
	{
		StartCoroutine (LoadAsyncly (sceneIndex));

	}

	IEnumerator LoadAsyncly (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		loadingScreen.SetActive (true);
		prevMenu.SetActive (false);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01 (operation.progress/.9f);
			loadingBar.value = progress;

			yield return null;
		}
	}
}
