using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterZone : MonoBehaviour
{
    private Transform head;
    private Transform body;
    private Transform feet;

    private void Start()
    {
        head = transform.GetChild(0);
        body = transform.GetChild(1);
        feet = transform.GetChild(2);
    }

    public void SetPart(GameObject go, Rigidbody2D rb2D)
    {
        if (go.name == "head")
            go.transform.position = head.position;

        else if (go.name == "body")
            go.transform.position = body.position;

        else if (go.name == "feet")
            go.transform.position = feet.position;
        else
            return;

        go.transform.rotation = Quaternion.Euler(Vector3.zero);
        rb2D.gravityScale = 0;
        rb2D.velocity = Vector2.zero;
        rb2D.freezeRotation = true;
        go.GetComponent<Collider2D>().enabled = false;

    }
}
