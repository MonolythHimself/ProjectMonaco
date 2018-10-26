using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(menuName="Spell")]
public class SpellDeets : ScriptableObject
{
	public string spellname;
	public string spelltype;
	public float activeTime;
	public float reloadTime;

	public bool startSpellTiming;
	public bool reloading;

	public Color spellButtonColor;

	public Image spellImage;

	public SpellButton spellButton;

	public GameObject spellObject;

}
