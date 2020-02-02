using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public float delay = 2.5f; 
    public PartBody[] partBody;

    float chrono = 0;
    LootManager lootManager;

    private void Start()
    {
        lootManager = GetComponent<LootManager>(); 
    }

    private void Update()
    {
        chrono += Time.deltaTime; 
        if (chrono >= delay)
        {
            AddRandomLoot(); 
            chrono = 0; 
        }
    }

    void AddRandomLoot()
    {
        int randomNumber_1 = Random.Range(0, partBody.Length);
        lootManager.stockPart_P1.Add(partBody[randomNumber_1]);
        int randomNumber_2 = Random.Range(0, partBody.Length);
        lootManager.stockPart_P2.Add(partBody[randomNumber_2]);
    }
}
