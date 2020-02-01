using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PickUpSystem : MonoBehaviour
{
    public UnityEvent Gibs;

    public float originalRotation;

    private void Start()
    {
        originalRotation = transform.eulerAngles.y;
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(0, originalRotation, transform.eulerAngles.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "PickUp")
        {
            Gibs.Invoke(); 
        }
    }
}
