using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    public Transform shootPoint;
    public Vector2 hitPoint;    

    public EdgeCollider2D EdgeCollider;
    Vector2[] colliderPoints;

    public LayerMask GRoundLayer;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        colliderPoints = EdgeCollider.points;

        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, Vector2.up, 100f);

        if (hit)
        {
            //Debug.Log(hit.collider.name);
            hitPoint = hit.point;

        }

        //Set the collider
        colliderPoints[0] = shootPoint.position;
        colliderPoints[1] = hitPoint;
        EdgeCollider.points = colliderPoints;

        lr.SetPosition(index: 0, shootPoint.position);
        lr.SetPosition(index: 1, hitPoint);
    }

    private void Update()
    {  
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, Vector2.up, 100f, GRoundLayer);

        if (hit)
        {
            Debug.Log(hit.point);
            
            hitPoint = hit.point;
            
        }

        lr.SetPosition(index: 0, shootPoint.position);
        lr.SetPosition(index: 1, hitPoint);

        //Set the collider
        colliderPoints[0] = shootPoint.position;
        colliderPoints[1] = hitPoint;
        EdgeCollider.points = colliderPoints;

        if (Input.GetKeyDown(KeyCode.L))
        {
            SetLineAndCollider();
        }

    }

    void SetLineAndCollider ()
    {
        lr.SetPosition(index: 0, shootPoint.position);
        lr.SetPosition(index: 1, hitPoint);

        //Set the collider
        colliderPoints[0] = shootPoint.position;
        colliderPoints[1] = hitPoint;
        EdgeCollider.points = colliderPoints;

    }
}
