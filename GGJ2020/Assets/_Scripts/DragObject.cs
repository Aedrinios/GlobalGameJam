using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera mainCamera;

    private Rigidbody2D rb2D;

    private Vector3 convertMousePosition;
    private Vector2 screenMousePosition;
    private Vector2 mouseDirection;
    private Vector2 convertTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
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
        mouseDirection = (screenMousePosition - convertTransform).normalized;
        rb2D.AddForce(mouseDirection * Time.fixedDeltaTime);
    }
}
