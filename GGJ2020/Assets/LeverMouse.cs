using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMouse : MonoBehaviour
{
    public CharacterZone charZone;

    private void OnMouseDown()
    {
        charZone.CreateCreature();
    }
}
