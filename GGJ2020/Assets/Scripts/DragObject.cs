using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DragObject : MonoBehaviour
{
    public PartBody partBody;
    #region Components
    private Camera mainCamera;
    private Rigidbody2D rb2D;
    private Collider2D col;
    private SpriteRenderer spriteRenderer; 
    #endregion

    #region Vectors and conversion
    private Vector3 convertMousePosition;
    private Vector2 screenMousePosition;
    private Vector2 mouseDirection;
    private Vector2 convertTransform;
    #endregion

    public static float tolerance = 5;
    public static float grabForce = 100;

    private float distanceWithMouse;
    private int layerMask;

    private void Start()
    {
        InitialiseDrag();
        layerMask = 1 << 13;        
        mainCamera = Camera.main;
        rb2D = GetComponent<Rigidbody2D>();
        gameObject.AddComponent<PolygonCollider2D>();
        col = GetComponent<Collider2D>();
    }

    void InitialiseDrag()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = partBody.spritePart;
        if(partBody.typePart == Enum.Type.Body)
        {
            spriteRenderer.sortingOrder = 0;
        }
        if (partBody.typePart == Enum.Type.Head && partBody.typePart == Enum.Type.Member)
        {
            spriteRenderer.sortingOrder = 1;
        }
        gameObject.name = partBody.spritePart.name; 
    }

    private void OnMouseDown()
    {
        rb2D.gravityScale = 0;        
    }

    private void OnMouseDrag()
    {
        col.enabled = false;
        convertMousePosition = Input.mousePosition;
        convertMousePosition.z = 10;
        convertMousePosition = mainCamera.ScreenToWorldPoint(convertMousePosition);
        screenMousePosition = convertMousePosition;
        FollowMouse();
    }

    private void FollowMouse()
    {
        convertTransform = transform.position;
        mouseDirection = screenMousePosition - convertTransform;
        distanceWithMouse = mouseDirection.magnitude;
        mouseDirection.Normalize();
        rb2D.AddForce(mouseDirection * Time.fixedDeltaTime * grabForce * distanceWithMouse);
        if(distanceWithMouse > tolerance)
        {
            rb2D.drag = 0;
        }
        else
        {
            rb2D.drag = 1 + (1/distanceWithMouse);
        }
    }

    private void OnMouseUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(convertMousePosition, Vector3.forward, Mathf.Infinity, layerMask);
        if(hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<CharacterZone>().SetPart(gameObject, rb2D);
        }
        else
        {
            col.enabled = true;
        }
    }
}
