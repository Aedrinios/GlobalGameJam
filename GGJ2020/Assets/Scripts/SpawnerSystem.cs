using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    public GameObject monsterPlayer;

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
        if(monsterPlayer != null)
        {
            GameObject newMonster = Instantiate(monsterPlayer, transform.position, transform.rotation) as GameObject;
            newMonster.GetComponent<MonsterSystem>().player = player;
        }

        else
        {
            Debug.Log("Monster not created");
        }
    }

    public void SetMonster(GameObject monsterPrefab)
    {
        monsterPlayer = monsterPrefab;
    }

}
