using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerController : MonoBehaviour
{
    private bool MovingStriker = false;
    public float MovingSpeed = 20f;
    private Rigidbody StrikerRB;
    private Camera MainCam;
    public LayerMask GroundLayer;

    private Vector3 TargetPoint;

    private void Start()
    {
        StrikerRB = GetComponent<Rigidbody>();
        MainCam = Camera.main;
    }

    private void Update()
    {
        if (MovingStriker)
        {
            Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, GroundLayer))
            {
                Vector3 targetPoint = hit.point;
                targetPoint.y = StrikerRB.position.y;
                //TargetPoint = hit.point;
                //TargetPoint.y = StrikerRB.position.y;
                Vector3 dir = (targetPoint - StrikerRB.position).normalized;
                StrikerRB.MovePosition(StrikerRB.position + MovingSpeed * Time.deltaTime * dir);
                //StrikerRB.AddForce(MovingSpeed * dir, ForceMode.VelocityChange);
                //StrikerRB.velocity = MovingSpeed * dir;
            }
        }
    }

    private void FixedUpdate()
    {
        if (MovingStriker)
        {
            /*Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, GroundLayer))
            {
                Vector3 targetPoint = hit.point;
                targetPoint.y = StrikerRB.position.y;
                Vector3 dir = (targetPoint - StrikerRB.position).normalized;
                //StrikerRB.MovePosition(StrikerRB.position + MovingSpeed * Time.deltaTime * dir);
                //StrikerRB.AddForce(MovingSpeed * dir, ForceMode.VelocityChange);
                StrikerRB.velocity = MovingSpeed * dir;
            }*/
            /*if (Vector3.Distance(StrikerRB.position, TargetPoint) > 0.5f)
            {
                Vector3 dir = (TargetPoint - StrikerRB.position).normalized;
                StrikerRB.AddForce(MovingSpeed * dir, ForceMode.VelocityChange);
                //StrikerRB.velocity = MovingSpeed * dir;
            }
            else
            {
                StrikerRB.velocity = Vector3.zero;
            }*/
        }
    }

    private void OnMouseDown()
    {
        //StrikerRB.constraints = RigidbodyConstraints.FreezePositionY;
        MovingStriker = true;
    }

    private void OnMouseUp()
    {
        MovingStriker = false;
        StrikerRB.velocity = Vector3.zero;
    }
}
