using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienChase : MonoBehaviour
{
    public LineRenderer rightLr, leftLr;
    private Vector3 rightHitPoint, leftHitPoint;
    private Vector3 offset = new Vector3(3f, 0f, 0f);
    public Transform rightShootPoint, leftShootPoint;
    public EdgeCollider2D rightCollider;
    public EdgeCollider2D leftCollider;

    public AlienMovement movementScript;

    private bool isChasing = true;

    Vector2[] colliderPoints;


    private void Start()
    {
        colliderPoints = rightCollider.points;
            
    }

    private void Update()
    {
        if (!isChasing)
            return;
        
        //For the right line
        RaycastHit2D hit = Physics2D.Raycast(rightShootPoint.position, Vector2.right, 100f);

        if(hit)
        {
            //Debug.Log(hit.collider.name);
            rightHitPoint = hit.point;
            
        }
        
        rightLr.SetPosition(index: 0, rightShootPoint.position);
        rightLr.SetPosition(index: 1, rightHitPoint);

        //Set the collider
        colliderPoints[0] = rightShootPoint.position;
        colliderPoints[1] = rightHitPoint;
        rightCollider.points = colliderPoints;


        //For the left line
        RaycastHit2D lefthit = Physics2D.Raycast(leftShootPoint.position, Vector2.left, 100f);

        if (lefthit)
        {
            leftHitPoint = lefthit.point;
        }

        leftLr.SetPosition(index: 0, leftShootPoint.position);
        leftLr.SetPosition(index: 1, leftHitPoint);

        //Set the collider
        leftCollider.points[0] = leftShootPoint.position;
        leftCollider.points[1] = leftHitPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player" || collision.gameObject.transform.position.y > transform.position.y)
        {
            //Das Alien "ausschalten"
            isChasing = false;
            rightLr.enabled = false;
            leftLr.enabled = false;

        }
    }
}
