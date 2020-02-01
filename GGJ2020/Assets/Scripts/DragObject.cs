using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    #region Components
    private Camera mainCamera;
    private Rigidbody2D rb2D;
    #endregion

    #region Vectors and conversion
    private Vector3 convertMousePosition;
    private Vector2 screenMousePosition;
    private Vector2 mouseDirection;
    private Vector2 convertTransform;
    #endregion

    public float tolerance;
    public float grabForce;
    private float distanceWithMouse;

    private void Start()
    {
        mainCamera = Camera.main;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        rb2D.gravityScale = 0;
    }

    private void OnMouseDrag()
    {
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
}
