using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DisplayStatsHUD : MonoBehaviour
{
	public Text forceText;
	public Text pvText;
	public Text vitesseText;

	public float forceValue = 0;
	public float pvValue = 0;
	public float vitesseValue = 0;

	string forceDisplay;
	string pvDisplay;
	string vistesseDisplay;

	private void Update()
	{
		forceDisplay = forceValue.ToString();
		pvDisplay = pvValue.ToString();
		vistesseDisplay = vitesseValue.ToString();

		forceText.text = forceDisplay;
		pvText.text = pvDisplay;
		vitesseText.text = vistesseDisplay; 
	}

	void TakeMonsterStats()
	{






	}



}
