using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    private GameObject monsterSpawn; 

    public KeyCode SpawnButton;
    public Enum.Player player = Enum.Player.Player_1;

    private void Update()
    {
        if (Input.GetKeyDown(SpawnButton))
        {
            SpawnNewMonster(); 
        }
    }

    public void SpawnNewMonster()
    {
        if(monsterSpawn != null)
        {
            GameObject newMonster = Instantiate(monsterSpawn, transform.position, transform.rotation) as GameObject;
            newMonster.GetComponent<MonsterSystem>().player = player;
        }
        else
        {
            Debug.Log("Monster not created");
        }
    }
}
