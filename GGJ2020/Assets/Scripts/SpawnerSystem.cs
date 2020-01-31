using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    public GameObject monsterSpawn; 

    public KeyCode SpawnButton;
    public Enum.Side sideSpawn = Enum.Side.Left;

    private void Update()
    {
        if (Input.GetKeyDown(SpawnButton))
        {
            SpawnNewMonster(); 
        }
    }

    public void SpawnNewMonster()
    {
        GameObject newMonster = Instantiate(monsterSpawn, transform.position, transform.rotation) as GameObject;
        newMonster.GetComponent<MonsterSystem>().side = sideSpawn; 
    }
}
