using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PartSystem : MonoBehaviour
{
    public PartBody partBody;    
    [HideInInspector] public Enum.Type typePart = Enum.Type.Body;

    [HideInInspector] public int bonusStrength;
    [HideInInspector] public int bonusConstitution;
    [HideInInspector] public int bonusAgility;

    private void Awake()
    {
        if (partBody != null)
        {
            bonusStrength = partBody.bonusStrength;
            bonusConstitution = partBody.bonusConstitution;
            bonusAgility = partBody.bonusAgility;

            typePart = partBody.typePart;
            SpriteRenderer renderer = GetComponent<SpriteRenderer>(); 
            renderer.sprite = partBody.spritePart;
            if (typePart == Enum.Type.Head) renderer.sortingOrder = 2;
            else if (typePart == Enum.Type.Member) renderer.sortingOrder = 1;
        }
    }
}
