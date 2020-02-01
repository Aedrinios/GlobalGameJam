using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PickUpSystem : MonoBehaviour
{
    public UnityEvent Gibs;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "PickUp")
        {
            Gibs.Invoke(); 
        }
    }
}
