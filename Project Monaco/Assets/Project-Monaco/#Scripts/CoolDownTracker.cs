using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownTracker : MonoBehaviour 
{

	public SpellButton spellButton1;
	public SpellButton spellButton2;
	public SpellButton spellButton3;
	public SpellButton spellButton4;

	SpellSystem spel;

	float spare1;
	float spare2;
	float spare3;
	float spare4;

	public void Start()
	{
		spel = FindObjectOfType<SpellSystem> ();
	}

	void Update ()
	{
		if(spellButton1.spellr != null)
			if (spellButton1.spellr.spell.startSpellTiming == true)
			{
				spel.lifeBar.value = spellButton1.timer;
				spellButton1.timer -= Time.deltaTime;
			}
			else if (spellButton1.spellr.spell.startSpellTiming != true)
			{
				spellButton1.spellr.spellObject.SetActive (false);
			}

		if(spellButton1.spellr != null)
			if (spellButton1.timer <= 0f && spellButton1.spellr.spell.startSpellTiming == true)
			{
				spellButton1.timer = 0f;
				spellButton1.spellr.spell.startSpellTiming = false;
				spellButton1.spellr.spell.reloading = true;
				spare1 = spellButton1.spellr.spell.reloadTime;
			}

		if(spellButton1.spellr != null)
			if (spellButton1.spellr.spell.reloading == true)
			{
				spare1 -= Time.deltaTime;
				spellButton1.spellText.text = " " + spare1;
				spellButton1.enabled= false;
			}

		if(spellButton1.spellr != null)
			if (spare1 <= 0f && spellButton1.spellr.spell.reloading == true)
			{
				spare1 = spellButton1.spellr.spell.reloadTime;
				spellButton1.spellr.spell.reloading = false;
				spellButton1.timer = spellButton1.spellr.spell.activeTime;
				spellButton1.enabled=true;
				spellButton1.spellText.text = spellButton1.spellr.spell.spellname;
			}

		//
		if(spellButton2.spellr != null)
			if (spellButton2.spellr.spell.startSpellTiming == true)
			{
				spel.lifeBar.value = spellButton2.timer;
				spellButton2.timer -= Time.deltaTime;
			}
			else if (spellButton2.spellr.spell.startSpellTiming != true)
				{
				if(spellButton2.spellr != null)
					spellButton2.spellr.spellObject.SetActive (false);
				
				}

		if(spellButton2.spellr != null)
			if (spellButton2.timer <= 0f && spellButton2.spellr.spell.startSpellTiming == true)
			{
				spellButton2.timer = 0f;
				spellButton2.spellr.spell.startSpellTiming = false;
				spellButton2.spellr.spell.reloading = true;
				spare2 = spellButton2.spellr.spell.reloadTime;
			}

		if(spellButton2.spellr != null)
			if (spellButton2.spellr.spell.reloading == true)
			{
				spare2 -= Time.deltaTime;
				spellButton2.spellText.text = " " + spare1;
				spellButton2.enabled= false;
			}

		if(spellButton2.spellr != null)
			if (spare2 <= 0f && spellButton2.spellr.spell.reloading == true)
			{
				spare2 = spellButton2.spellr.spell.reloadTime;
				spellButton2.spellr.spell.reloading = false;
				spellButton2.timer = spellButton2.spellr.spell.activeTime;
				spellButton2.enabled=true;
				spellButton2.spellText.text = spellButton2.spellr.spell.spellname;
			}
		
		//
		if(spellButton3.spellr != null)
			if (spellButton3.spellr.spell.startSpellTiming == true)
			{
				spel.lifeBar.value = spellButton3.timer;
				spellButton3.timer -= Time.deltaTime;
			}
			else if (spellButton3.spellr.spell.startSpellTiming != true)
				{
				if(spellButton3.spellr != null)
					spellButton3.spellr.spellObject.SetActive (false);

			}

			if(spellButton3.spellr != null)
			if (spellButton3.timer <= 0f && spellButton3.spellr.spell.startSpellTiming == true)
			{
				spellButton3.timer = 0f;
				spellButton3.spellr.spell.startSpellTiming = false;
				spellButton3.spellr.spell.reloading = true;
				spare3 = spellButton3.spellr.spell.reloadTime;
			}

			if(spellButton3.spellr != null)
			if (spellButton3.spellr.spell.reloading == true)
			{
				spare3 -= Time.deltaTime;
				spellButton3.spellText.text = "  :  " + spare3;
				spellButton3.enabled=false;
			}

			if(spellButton3.spellr != null)
			if (spare3 <= 0f && spellButton3.spellr.spell.reloading == true)
			{
				spare3 = spellButton3.spellr.spell.reloadTime;
				spellButton3.spellr.spell.reloading = false;
				spellButton3.timer = spellButton3.spellr.spell.activeTime;
				spellButton3.enabled=true;
				spellButton3.spellText.text = spellButton3.spellr.spell.spellname;
			}
		

		//
		if(spellButton4.spellr != null)
			if (spellButton4.spellr != null &&spellButton4.spellr.spell.startSpellTiming == true)
			{
				spel.lifeBar.value = spellButton4.timer;
				spellButton4.timer -= Time.deltaTime;
			}
		else if (spellButton4.spellr.spell.startSpellTiming != true)
				{
				if(spellButton4.spellr != null)
					spellButton4.spellr.spellObject.SetActive (false);

			}

		if(spellButton4.spellr != null)
			if (spellButton4.timer <= 0f && spellButton4.spellr.spell.startSpellTiming == true)
			{
				spellButton4.timer = 0f;
				spellButton4.spellr.spell.startSpellTiming = false;
				spellButton4.spellr.spell.reloading = true;
				spare4 = spellButton4.spellr.spell.reloadTime;
			}

		if(spellButton4.spellr != null)
			if (spellButton4.spellr.spell.reloading == true)
			{
				spare4 -= Time.deltaTime;
				spellButton4.spellText.text = " " + spare4;
				spellButton4.enabled=false;
			}

		if(spellButton4.spellr != null)
			if (spare4 <= 0f && spellButton4.spellr.spell.reloading == true)
			{
				spare4 = spellButton4.spellr.spell.reloadTime;
				spellButton4.timer = spellButton4.spellr.spell.activeTime;
				spellButton4.spellr.spell.reloading = false;
				spellButton4.enabled=true;
				spellButton4.spellText.text = spellButton4.spellr.spell.spellname;
			}
	}
}
