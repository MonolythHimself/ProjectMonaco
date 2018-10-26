using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapKeyStorage : ScriptableObject
{
 
	public string[] levelKeys;
	//Don't forget a foreach loop for the string index.

	public int levelNumIND;

	public int attributeWidth;
	public int attributeHeight;

	public int fillRateForFillPercent;
}
