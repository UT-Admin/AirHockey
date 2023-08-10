using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerController : MonoBehaviour
{
    private bool MovingStriker = false;
    public float MovingSpeed = 20f;
    private Rigidbody StrikerRB;

    private void Start()
    {
        StrikerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (MovingStriker)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, 10));
            Debug.Log($"Mouse position: {mousePos}");
            mousePos.y = transform.position.y;
            StrikerRB.MovePosition(mousePos);
        }
    }

    private void OnMouseDown()
    {
        MovingStriker = true;
    }

    private void OnMouseUp()
    {
        MovingStriker = false;
    }
}
