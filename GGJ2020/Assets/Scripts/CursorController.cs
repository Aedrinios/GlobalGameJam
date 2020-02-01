using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Enum.Player player = Enum.Player.Player_1; 
    public float speed = 10;
    public float maxX = 17.8f;
    public float maxY = 10.7f;


    private void FixedUpdate()
    {
        if (player == Enum.Player.Player_1)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
        }
        if (player == Enum.Player.Player_2)
        {
            float h = Input.GetAxis("Horizontal2");
            float v = Input.GetAxis("Vertical2");
            transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, -maxX, maxX);
        clampPosition.y = Mathf.Clamp(clampPosition.y, -maxY, maxY);
        transform.position = clampPosition; 
    }
}
