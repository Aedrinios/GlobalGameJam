using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Enum.Player player = Enum.Player.Player_1; 
    public float speed = 10;
    public float maxX = 17.8f;
    public float maxY = 10.7f;

    private GameObject grabbedObject;
    private CharacterZone charZone;

    private int layerMaskGrab;
    private int layerMaskRelease;
    private bool hasGrabbed;

    private void Start()
    {
        hasGrabbed = false;
        layerMaskGrab = 1 << 12;
        layerMaskRelease = 1 << 13;
        charZone = FindObjectOfType<CharacterZone>();
    }

    private void FixedUpdate()
    {
        if (player == Enum.Player.Player_1)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
            if (Input.GetButtonDown("Grab1"))
            {
                ActivateLever();
            }
            if (Input.GetButton("Grab1") && !hasGrabbed)
            {
                GrabObject();
            }
            if(Input.GetButtonUp("Grab1") && hasGrabbed)
            {
                ReleaseObject();
            }
        }
        if (player == Enum.Player.Player_2)
        {
            float h = Input.GetAxis("Horizontal2");
            float v = Input.GetAxis("Vertical2");
            transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
            if (Input.GetButton("Grab2") && !hasGrabbed)
            {
                GrabObject();
            }
            if (Input.GetButtonUp("Grab2") && hasGrabbed)
            {
                ReleaseObject();
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, -maxX, maxX);
        clampPosition.y = Mathf.Clamp(clampPosition.y, -maxY, maxY);
        transform.position = clampPosition; 
    }

    private void GrabObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, Mathf.Infinity, layerMaskGrab);
        if(hit.collider != null)
        {
            grabbedObject = hit.collider.gameObject;
            grabbedObject.transform.parent = transform;
            grabbedObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            grabbedObject.GetComponent<Collider2D>().enabled = false;
            hasGrabbed = true;
        }
    }

    private void ReleaseObject()
    {
        grabbedObject.transform.parent = null;
        grabbedObject.GetComponent<Collider2D>().enabled = true;
        hasGrabbed = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, Mathf.Infinity, layerMaskRelease);
        if (hit.collider != null)
        {
            charZone.SetPart(grabbedObject, grabbedObject.GetComponent<Rigidbody2D>());
        }

    }

    private void ActivateLever()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, Mathf.Infinity);
        if (hit.collider != null && hit.collider.CompareTag("Lever"))
        {
            charZone.CreateCreature();
        }
    }
}
