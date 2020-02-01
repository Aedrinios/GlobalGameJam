using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PartBody : ScriptableObject
{
	
	public Enum.Type typePart = Enum.Type.Body; 

	public Sprite spritePart;

	public int bonusStrength = 0;
	public int bonusConstitution = 0;
	public int bonusAgility = 0;

	public string description; 
}
