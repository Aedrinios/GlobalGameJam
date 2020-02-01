using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    public int strength = 10;
    public int constitution = 10;
    public int agility = 10;
    public int gestation = 0;

    PartSystem[] allPartSystem; 

    public void UpgradeStats()
    {
        allPartSystem = GetComponentsInChildren<PartSystem>();

        for (int i = 0; i < allPartSystem.Length; i++)
        {
            strength += allPartSystem[i].bonusStrength;
            constitution += allPartSystem[i].bonusConstitution;
            agility += allPartSystem[i].bonusAgility;
        }
    }


}
