using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformKiller : MonoBehaviour 
{

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Platform")
		{
			DestroyImmediate(other.gameObject);
		}
	}

}
