using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DisplayStatsHUD : MonoBehaviour
{
	public GameObject monsterEmpty;
	public CharacterZone characterZone; 
	public Color colorText; 

	public Text forceText;
	public Text pvText;
	public Text vitesseText;

	public float forceValue = 0;
	public float pvValue = 0;
	public float vitesseValue = 0;

	public float forceBonus = 0;
	public float pvBonus= 0;
	public float vitesseBonus = 0;

	string forceDisplay;
	string pvDisplay;
	string vistesseDisplay;

	MonsterStats monsterStats;
	MonsterSystem monsterSystem;
	bool noMonster = true;

	private void Start()
	{
		forceText.color = colorText;
		pvText.color = colorText;
		vitesseText.color = colorText;

		monsterStats = monsterEmpty.GetComponent<MonsterStats>();
		monsterSystem = monsterEmpty.GetComponent<MonsterSystem>();
	}

	private void Update()
	{
		TakeMonsterStats(); 
		forceDisplay = forceValue.ToString();
		pvDisplay = pvValue.ToString();
		vistesseDisplay = vitesseValue.ToString();

		forceText.text = forceDisplay;
		pvText.text = pvDisplay;
		vitesseText.text = vistesseDisplay; 
	}

	void TakeMonsterStats()
	{
		DetectPartBody();
		forceValue = monsterSystem.powerAttack * (monsterStats.strength + forceBonus);
		pvValue = monsterSystem.life * (monsterStats.constitution + pvBonus);
		vitesseValue = monsterSystem.speedMove * monsterSystem.multiplierBonusSpeed * (monsterStats.constitution + vitesseBonus);

		if (noMonster)
		{
			forceValue = 0;
			pvValue = 0;
			vitesseValue = 0;
		}
	}

	void DetectPartBody()
	{
		GameObject head = characterZone.head;
		GameObject arm = characterZone.arm;
		GameObject body = characterZone.body;
		GameObject feet = characterZone.feet;
		GameObject[] allPart = {head, arm, body, feet };

		forceBonus = 0;
		pvBonus = 0;
		vitesseBonus = 0;
		noMonster = true;

		for (int i = 0; i < allPart.Length; i++)
		{
			if (allPart[i] != null)
			{
				PartBody part = allPart[i].GetComponent<DragObject>().partBody;
				forceBonus += part.bonusStrength;
				pvBonus += part.bonusConstitution;
				vitesseBonus += part.bonusAgility;
				noMonster = false; 
			}
		}
	}
}
