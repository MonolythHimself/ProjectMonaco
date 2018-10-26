using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWatch : MonoBehaviour 
{

	public Transform player;

	public Transform restartObject;

	EnemySpawns spawners;

	public bool playerDead;

	public GameObject portal;

	float wait=00.1f;

	float winTimeDelay = 5f ;

	public int thisScene;

	void Start () 
	{
		spawners = FindObjectOfType<EnemySpawns> ();
	    restartObject.gameObject.SetActive (false);
		playerDead = false;
	}
		
	void Update()
	{
		if (spawners != null)
		{
			if (spawners==null || spawners.enabled==false || spawners.gameObject == null)
			{
				winTimeDelay -= Time.deltaTime;
			}
		}

		if (winTimeDelay <= 0f)
		{
			winTimeDelay = 0f;
		//	if(portal !=null)
		//	portal.SetActive (true);
		}

		if (player != null && player.gameObject.GetComponent<PlayerControl> ().enabled == false)
		{
			wait -= Time.deltaTime;
		}
		else if (FindObjectOfType<EnemySpawns> () != null && FindObjectOfType<EnemySpawns> ().enemyCount == 0)
			{
			wait -= Time.deltaTime;
			}
			
		if (wait <= 0f && (FindObjectOfType<SpellSystem> ().spelling != true || FindObjectOfType<SpellSystem> ().spelling == true) && FindObjectOfType<PauseScript4MapScreen> ().paused != true)
		{
			restartObject.gameObject.SetActive (true);
		}

		if (Input.anyKey && restartObject.gameObject.activeSelf == true)
		{
			restartObject.gameObject.SetActive (false);
			SceneManager.LoadScene(thisScene);
		}	
	}
}
