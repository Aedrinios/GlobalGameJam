using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterZone : MonoBehaviour
{
    public Enum.Player player = Enum.Player.Player_1;
    public SpawnerSystem spawnPlayer;
    public GameObject monsterPrefab;
    public Vector3 rescale;


    [SerializeField] private Vector3 placementPosition = Vector3.zero;
    private bool hasHead;
    private bool hasArm;
    private bool hasBody;
    private bool hasFeet;

    private PartBody head;
    private Sprite spriteHead;
    private PartBody arm;
    private Sprite spriteArm;
    private PartBody body;
    private Sprite spriteBody;
    private PartBody feet;
    private Sprite spriteFeet;

    public void SetPart(GameObject go, Rigidbody2D rb2D)
    {
        if ((go.name.ToUpper().Contains("HEAD") || go.name.ToUpper().Contains("TETE")) && !hasHead)
        {            hasHead = true;
            head = go.GetComponent<DragObject>().partBody;
        }
        else if ((go.name.ToUpper().Contains("ARM") || go.name.ToUpper().Contains("PATTES_H")) && !hasHead)
        {
            hasArm = true;
            arm = go.GetComponent<DragObject>().partBody;
        }

        else if ((go.name.ToUpper().Contains("BODY") || go.name.ToUpper().Contains("CORPS")) && !hasBody)
        {
            hasBody = true;
            body = go.GetComponent<DragObject>().partBody;
        }

        else if ((go.name.ToUpper().Contains("FEET") || go.name.ToUpper().Contains("PATTES_B")) && !hasFeet)
        {
            hasFeet = true;
            feet = go.GetComponent<DragObject>().partBody;
        }
        else
            return;

        go.transform.localScale = rescale;
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
        rb2D.gravityScale = 0;
        rb2D.velocity = Vector2.zero;
        rb2D.freezeRotation = true;
        go.GetComponent<Collider2D>().enabled = false;
        go.transform.position = placementPosition;
    }

    public void CreateCreature()
    {
        monsterPrefab.transform.GetChild(0).GetComponent<PartSystem>().partBody = head;
        monsterPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteHead;
        monsterPrefab.transform.GetChild(1).GetComponent<PartSystem>().partBody = arm;
        monsterPrefab.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteArm;
        monsterPrefab.transform.GetChild(2).GetComponent<PartSystem>().partBody = body;
        monsterPrefab.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = spriteBody;
        monsterPrefab.transform.GetChild(3).GetComponent<PartSystem>().partBody = feet;
        monsterPrefab.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = spriteFeet;

        if (player == Enum.Player.Player_1)
        {
            spawnPlayer.SetMonster(monsterPrefab);
        }
    }
}
