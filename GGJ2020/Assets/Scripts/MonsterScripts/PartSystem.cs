using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class PartSystem : MonoBehaviour
{
    public PartBody partBody;    
    [HideInInspector] public Enum.Type typePart = Enum.Type.Body;

    [HideInInspector] public int bonusStrength;
    [HideInInspector] public int bonusConstitution;
    [HideInInspector] public int bonusAgility;

    private void OnEnable()
    {
        InitiatePartBody();
    }

    void InitiatePartBody()
    {
        if (partBody != null)
        {
            bonusStrength = partBody.bonusStrength;
            bonusConstitution = partBody.bonusConstitution;
            bonusAgility = partBody.bonusAgility;

            gameObject.name = partBody.name; 
            typePart = partBody.typePart;
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = partBody.spritePart;
            if (typePart == Enum.Type.Head) renderer.sortingOrder = 4;
            else if (typePart == Enum.Type.Member) renderer.sortingOrder = 2;
            else if (typePart == Enum.Type.Body) renderer.sortingOrder = 0;
        }
    }
}
