using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterZone : MonoBehaviour
{
    public SpawnerSystem spawnPlayer;
    public GameObject monsterPrefab;
    public Vector3 rescale;


    [SerializeField] private Vector3 placementPosition = Vector3.zero;
    private bool hasHead;
    private bool hasArm;
    private bool hasBody;
    private bool hasFeet;

    private GameObject head;
    private Sprite spriteHead;
    private GameObject arm;
    private Sprite spriteArm;
    private GameObject body;
    private Sprite spriteBody;
    private GameObject feet;
    private Sprite spriteFeet;

    public void SetPart(GameObject go, Rigidbody2D rb2D)
    {
        Debug.Log("MOHAMMED AVDOL");
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
        go.transform.position = placementPosition;
    }

    public void CreateCreature()
    {
        monsterPrefab.transform.GetChild(0).GetComponent<PartSystem>().partBody = head.GetComponent<DragObject>().partBody;
        monsterPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteHead;
        monsterPrefab.transform.GetChild(1).GetComponent<PartSystem>().partBody = arm.GetComponent<DragObject>().partBody;
        monsterPrefab.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = spriteArm;
        monsterPrefab.transform.GetChild(2).GetComponent<PartSystem>().partBody = body.GetComponent<DragObject>().partBody;
        monsterPrefab.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = spriteBody;
        monsterPrefab.transform.GetChild(3).GetComponent<PartSystem>().partBody = feet.GetComponent<DragObject>().partBody;
        monsterPrefab.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = spriteFeet;

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
