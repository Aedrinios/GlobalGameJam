using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public float delayLoot = 5;
    public List<PartBody> stockPart_P1 = new List<PartBody>();
    public List<PartBody> stockPart_P2 = new List<PartBody>();

    public GameObject partCraft;
    public Vector3 spawnPointP1;
    public Vector3 spawnPointP2;

    float chrono = 0;

    private void Update()
    {
        chrono += Time.deltaTime; 
        if (chrono >= delayLoot)
        {
            LootToCraft(); 
            chrono = 0;
        }
    }

    void LootToCraft()
    {
        if (stockPart_P1.Count != 0)
        {
            GameObject newObject = Instantiate(partCraft, spawnPointP1, transform.rotation) as GameObject;
            newObject.GetComponent<DragObject>().partBody = stockPart_P1[0];
            newObject.GetComponent<DragObject>().InitialiseDrag(); 
            stockPart_P1.Remove(stockPart_P1[0]);
        }
        if (stockPart_P2.Count != 0)
        {
            GameObject newObject = Instantiate(partCraft, spawnPointP2, transform.rotation) as GameObject;
            newObject.GetComponent<DragObject>().partBody = stockPart_P2[0];
            newObject.GetComponent<DragObject>().InitialiseDrag();
            stockPart_P2.Remove(stockPart_P2[0]);
        }
    }



}
