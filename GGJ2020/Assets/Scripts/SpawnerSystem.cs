using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    public GameObject monsterPlayer;
    private GameObject newMonster;

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
            Debug.Log(monsterPlayer.GetComponent<MonsterStats>().gestation);

            newMonster = Instantiate(monsterPlayer, transform.position, transform.rotation) as GameObject;

            newMonster.SetActive(false);
            Invoke("LaunchMonster", newMonster.GetComponent<MonsterStats>().gestation);
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

    public void LaunchMonster()
    {
        newMonster.SetActive(true);
    }

}
