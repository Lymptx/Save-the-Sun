using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public Transform LaserSwitchEnd;
    public LayerMask laserSwitchLayer;
    public LayerMask WhatIsGround;

    public GameObject LaserEnd;
        
    public LineRenderer lr;

    private Vector2 hitPoint;

    public EdgeCollider2D edgeCollider;
    Vector2[] colliderPoints;

    private void Awake()
    {
        colliderPoints = edgeCollider.points;
        
    }

    private void Update()
    {    
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1000f, laserSwitchLayer);
        RaycastHit2D vertHit = Physics2D.Raycast(transform.position, Vector2.up, 1000f, laserSwitchLayer);
        RaycastHit2D downHit = Physics2D.Raycast(transform.position, Vector2.down, 1000f, laserSwitchLayer);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, 1000f, laserSwitchLayer);
        RaycastHit2D URhit = Physics2D.Raycast(transform.position, new Vector2(1f, 1f), 1000f, laserSwitchLayer);
        RaycastHit2D DRhit = Physics2D.Raycast(transform.position, new Vector2(1f, -1f), 1000f, laserSwitchLayer);
        RaycastHit2D DLhit = Physics2D.Raycast(transform.position, new Vector2(-1f, -1f), 1000f, laserSwitchLayer);
        RaycastHit2D ULhit = Physics2D.Raycast(transform.position, new Vector2(-1f, 1f), 1000f, laserSwitchLayer);

        //Set the point
        if (hit)
        {
            if (!Physics2D.Linecast(transform.position, hit.point, WhatIsGround))
            {

                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = hit.point;

                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }


        } else if (vertHit)
        {
            if (!Physics2D.Linecast(transform.position, vertHit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = vertHit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }

        } else if (downHit)
        {
            if (!Physics2D.Linecast(transform.position, downHit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = downHit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }

        } else if (leftHit)
        {
            if (!Physics2D.Linecast(transform.position, leftHit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = leftHit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }

        } else if (URhit)
        {
            if (!Physics2D.Linecast(transform.position, URhit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = URhit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }
        } else if (DRhit)
        {
            if (!Physics2D.Linecast(transform.position, DRhit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = DRhit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }
        } else if (DLhit)
        {
            if (!Physics2D.Linecast(transform.position, DLhit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = DLhit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }
        }
        else if (ULhit)
        {
            if (!Physics2D.Linecast(transform.position, ULhit.point, WhatIsGround))
            {
                if (lr.enabled == false)
                {
                    lr.enabled = true;
                    edgeCollider.enabled = true;
                }

                hitPoint = ULhit.point;

                Debug.Log("HitSthdf");
                lr.SetPosition(index: 0, transform.position);
                lr.SetPosition(index: 1, LaserEnd.transform.position);

                colliderPoints[0] = transform.position;
                colliderPoints[1] = hitPoint;
                edgeCollider.points = colliderPoints;
            }
        }
        else
        {
            if (lr.enabled == true)
            {
                lr.enabled = false;
                edgeCollider.enabled = false;
            }

        }

    }
}
