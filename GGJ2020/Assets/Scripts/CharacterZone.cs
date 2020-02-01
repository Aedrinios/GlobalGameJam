using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterZone : MonoBehaviour
{
    public Vector3 rescale;

    [SerializeField] private Vector3 placementPosition = Vector3.zero;
    private bool hasHead;
    private bool hasBody;
    private bool hasFeet;

    private void Start()
    {

    }

    public void SetPart(GameObject go, Rigidbody2D rb2D)
    {
        if (go.name.ToUpper().Contains("HEAD") && !hasHead)
            hasHead = true;

        else if (go.name.ToUpper().Contains("BODY") && !hasBody)
            hasBody = true;

        else if (go.name.ToUpper().Contains("FEET") && !hasFeet)
            hasFeet = true;
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
}
