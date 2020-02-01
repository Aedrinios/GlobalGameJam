using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterZone : MonoBehaviour
{
    public Enum.Player player;
    public SpawnerSystem spawnPlayer;
    public GameObject monsterPrefab;
    public Vector3 rescale;


    [SerializeField] private Vector3 placementPosition = Vector3.zero;
    private bool hasHead;
    private bool hasArm;
    private bool hasBody;
    private bool hasFeet;

    public GameObject head;
    private Sprite spriteHead;
    public GameObject arm;
    private Sprite spriteArm;
    public GameObject body;
    private Sprite spriteBody;
    public GameObject feet;
    private Sprite spriteFeet;

    public void SetPart(GameObject go, Rigidbody2D rb2D)
    {
        if ((go.name.ToUpper().Contains("HEAD") || go.name.ToUpper().Contains("TETE")) && !hasHead)
        {
            hasHead = true;
            head = go;
        }
        else if ((go.name.ToUpper().Contains("ARM") || go.name.ToUpper().Contains("PATTES_H")) && !hasArm)
        {
            hasArm = true;
            arm = go;
        }

        else if ((go.name.ToUpper().Contains("BODY") || go.name.ToUpper().Contains("CORPS")) && !hasBody)
        {
            hasBody = true;
            body = go;
        }

        else if ((go.name.ToUpper().Contains("FEET") || go.name.ToUpper().Contains("PATTES_B")) && !hasFeet)
        {
            hasFeet = true;
            feet = go;
        }
        else
            return;

        go.transform.localScale = rescale;
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
        rb2D.gravityScale = 0;
        rb2D.velocity = Vector2.zero;
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        go.GetComponent<Collider2D>().enabled = false;
        Debug.Log(placementPosition);
        go.transform.position = placementPosition;
        if(player == Enum.Player.Player_2)
            go.transform.eulerAngles = new Vector3(0, -180, 0);
    }

    public void CreateCreature()
    {
        if (body != null)
        {
            monsterPrefab.transform.GetChild(2).GetComponent<PartSystem>().partBody = body.GetComponent<DragObject>().partBody;
            monsterPrefab.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = spriteBody;
        }
        else
        {
            return;
        }

        if (head != null)
        {
            monsterPrefab.transform.GetChild(0).GetComponent<PartSystem>().partBody = head.GetComponent<DragObject>().partBody;
            monsterPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteHead;
        }

        if(arm != null)
        {
            monsterPrefab.transform.GetChild(1).GetComponent<PartSystem>().partBody = arm.GetComponent<DragObject>().partBody;
            monsterPrefab.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteArm;
        }

        if(feet != null)
        {
            monsterPrefab.transform.GetChild(3).GetComponent<PartSystem>().partBody = feet.GetComponent<DragObject>().partBody;
            monsterPrefab.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = spriteFeet;
        }

        spawnPlayer.SetMonster(monsterPrefab);
        spawnPlayer.SpawnNewMonster();
        Reset();
    }

    private void Reset()
    {
        if(head != null)
        {
            Destroy(head);
        }
        if (arm != null)
        {
            Destroy(arm);
        }
        if (body != null)
        {
            Destroy(body);
        }
        if (feet != null)
        {
            Destroy(feet);
        }
    }
}
