using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LifeBar : MonoBehaviour
{
    public MonsterSystem monsterSystem;
    float maxValue;
    float actualValue;

    Image img; 

    private void Start()
    {
        img = GetComponent<Image>();
        maxValue = monsterSystem.pvMax; 
    }

    private void Update()
    {
        actualValue = monsterSystem.life;
        img.fillAmount = actualValue / maxValue; 
    }

}
