using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionSeeker : MonoBehaviour 
{

	public Button seekerButton;

	public bool searching;

	public float initialSearchTime;

	public Color searchColor = Color.red;

	public Color foundColor=Color.green;

	public Text timeText;

	public Button kickOff;

	public float searchTime;

     public float searchSpeed;
	 public NavMeshAgent nav;

     //searching Variables
	private Vector3 searchTarget;
	public float searchRange = 50f;
	private NavMeshHit navmeshHit;
	private float nextCheck;
	float checkRate;
	private float sampleSize = 10.0f;

	int ranLevel;

	void Start ()
	{
		searching = false;
		seekerButton.interactable = false;
		seekerButton.gameObject.SetActive (false);
		searchTime = initialSearchTime;
		nav.speed=searchSpeed*Time.deltaTime;
	}
		
	void Update () 
	{
			if (searching)
			{
				Time.timeScale = 1;
				StartSeeking ();
				searching = true;
				timeText.text = "    "+searchTime;
				searchTime -= Time.deltaTime;
				seekerButton.GetComponentInChildren<Text> ().color = searchColor;
				seekerButton.GetComponentInChildren<Text> ().text = "Seeking Mission...";
				seekerButton.GetComponent<Image>().color = searchColor;
			}

			if (searchTime <= 0f && searching==true)
			{
				StopSeekingMissionFound ();
			}

		//For the UI Seeker Button.
		Vector3 barPos = Camera.main.WorldToScreenPoint (this.transform.position);
		if (seekerButton != null)
		{
			seekerButton.transform.position = barPos;
		}

		//For searching
		checkRate = Random.Range (-.3f, -1.5f)*Time.deltaTime;
		if (searching)
		{
			CheckIfIShouldSearch ();
		}
	}
	
	public void StartSeeking()
	{
		seekerButton.gameObject.SetActive (true);
		searching = true;
		StartSeeking ();
		searching = true;
		timeText.text = "    "+searchTime;
		searchTime -= Time.deltaTime;
		seekerButton.GetComponentInChildren<Text> ().color = searchColor;
		seekerButton.GetComponentInChildren<Text> ().text = "Seeking Mission...";
		seekerButton.GetComponent<Image>().color = searchColor;
		kickOff.gameObject.SetActive (false);	
	}
		
	public void LoadMission()
	{
		//randomLevel=(int)Random.Range(2f,3f);
		SceneManager.LoadScene(2);
	}

	void StopSeekingMissionFound()
	{
		kickOff.gameObject.SetActive (true);
		timeText.text = "PLAY";
		seekerButton.interactable=true;
		searching = false;
		searching = false;
		searchTime = initialSearchTime;
		seekerButton.GetComponentInChildren<Text> ().color = foundColor;
		seekerButton.GetComponentInChildren<Text> ().text = "MISSION FOUND";
		seekerButton.GetComponent<Image>().color = foundColor;
	}
		
	void CheckIfIShouldSearch()
	{
		if (nav != null)
		{
			if (RandomSearchTarget (transform.position, searchRange, out searchTarget))
			{   
			nav.speed = searchSpeed;
					nav.SetDestination (searchTarget);
			}
		}
      }
		
    bool RandomSearchTarget(Vector3 center,float RangeInt,out Vector3 result)
	{   
		Vector3 randomPoint = center + Random.insideUnitSphere * searchRange;

		if (NavMesh.SamplePosition (randomPoint,out navmeshHit, sampleSize, NavMesh.AllAreas))
		{
			result = navmeshHit.position; return true;
		}
		else
		{
			result = center; return false;
		}
	}

}
