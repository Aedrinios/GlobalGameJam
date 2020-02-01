using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public float delayLoot = 5;
    public List<PartBody> stockPart_P1 = new List<PartBody>();
    public List<PartBody> stockPart_P2 = new List<PartBody>();

    float chrono = 0;


    private void Update()
    {
        chrono += Time.deltaTime; 
        if (chrono >= delayLoot)
        {
            //CleanLoot();
            chrono = 0;
        }
    }

    public void CleanLoot()
    {
        GameObject[] pickUp = GameObject.FindGameObjectsWithTag("PickUp");

        for (int i = 0; i < pickUp.Length; i++)
        {
            PartSystem partSyst = pickUp[i].GetComponent<PartSystem>();

            stockPart_P1.Add(partSyst.partBody);
            Destroy(pickUp[i]);
        }
    } 

}
