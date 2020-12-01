using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ConnectBox : MonoBehaviour
{
    public bool collideWithPlayer;
    public bool collideWithObjects;
    //(Other Box)
    public Transform target;
    public LayerMask WhatIsGround;

    public GameObject[] IgnoreObjectLaserCollision;

    public EdgeCollider2D edgeCollider;
    private Vector2[] colliderPoints;

    public GameObject Player;

    public LineRenderer lr;
    public AudioSource myAudioSource;

    private void Awake()
    {
        colliderPoints = edgeCollider.points;

        if (!collideWithPlayer)
        {
             Physics2D.IgnoreCollision(edgeCollider, Player.GetComponent<PolygonCollider2D>());
        } 
          
        if (!collideWithObjects)
        {
            for (int i = 0; i < IgnoreObjectLaserCollision.Length; i++)
            {
                Physics2D.IgnoreCollision(edgeCollider, gameObject.GetComponent<BoxCollider2D>());
            }
        }

        ////Set the collider to ground Layer if collide with Player
        //if (collideWithPlayer)
        //{
        //    edgeCollider.gameObject.layer = 8;
        //}

        
    }

    private void Update()
    {
        if (!Physics2D.Linecast(transform.position, target.transform.position, WhatIsGround))
        {
            if (!lr.enabled)
                lr.enabled = true;

            //If collider is disabled, then enable it
            if (!edgeCollider.enabled)
            {
                edgeCollider.enabled = true;
                myAudioSource.enabled = true;

                //Play LaserOn Sound
                FindObjectOfType<Audio_Manager>().Play_("LaserOn");          

                //Ignore All Collidions !!!very important!!!
                if (!collideWithPlayer)
                {
                    Physics2D.IgnoreCollision(edgeCollider, Player.GetComponent<PolygonCollider2D>());
                }

                if (!collideWithObjects)
                {
                    for (int i = 0; i < IgnoreObjectLaserCollision.Length; i++)
                    {
                        Physics2D.IgnoreCollision(edgeCollider, gameObject.GetComponent<BoxCollider2D>());
                    }
                }
            }
                
            lr.SetPosition(index: 0, transform.position);
            lr.SetPosition(index: 1, target.transform.position);
                        
            //Make Collider
            colliderPoints[0] = transform.position;
            colliderPoints[1] = target.transform.position;
            edgeCollider.points = colliderPoints;

        } else
        {
            if (lr.enabled)
                lr.enabled = false;
        }

        if (Physics2D.Linecast(transform.position, target.transform.position, WhatIsGround))
        {
            if (lr.enabled)
                lr.enabled = false;

            //If collider is active then disable it
            if (edgeCollider.enabled)
            {
                edgeCollider.enabled = false;
                myAudioSource.enabled = false;

                //Play Laser Off Sound
                FindObjectOfType<Audio_Manager>().Play_("LaserOff");                
            }
        }
    }
    
}
