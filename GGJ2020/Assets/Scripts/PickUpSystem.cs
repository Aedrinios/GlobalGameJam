using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PickUpSystem : MonoBehaviour
{
    public float delay = 5; 

    public UnityEvent Gibs;
    float originalRotation;
    LootManager lootManager; 

    private void Start()
    {
        lootManager = FindObjectOfType<LootManager>(); 
        originalRotation = transform.eulerAngles.y;
        Invoke("GoToLoot", delay); 
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

    public void GoToLoot()
    {
        PartSystem partSyst = GetComponent<PartSystem>();
        if (partSyst.partBody != null)
        {
            float posX = transform.position.x;
            posX = (posX / 20f);
            float random = 0;
            random = Random.Range(-1f, 1f) + posX;

            if (random < 0f)
            {
                lootManager.stockPart_P1.Add(partSyst.partBody);
            }
            else
            {
                lootManager.stockPart_P2.Add(partSyst.partBody);
            }
        }
        Destroy(gameObject);
    }
}
