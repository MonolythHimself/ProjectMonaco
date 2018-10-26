using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

	public Animator cameraAnimator;

	public void CamShake()
	{
		int random = Random.Range (0, 3);

	//	if (random == 0){
			cameraAnimator.SetTrigger ("Shake");
		/*}else if (random == 1){cameraAnimator.SetTrigger ("Shake01");}
			else if (random == 2){cameraAnimator.SetTrigger ("Shake02");}*/
	}
}
