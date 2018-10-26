using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SoulKeeper : MonoBehaviour {

	public Text soulText;
	public int soulCount;

	void Update () 
	{
		if (soulText != null)
			soulText.text = "SOULS: " + soulCount;

	}
}
