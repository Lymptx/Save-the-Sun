using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool isPatrolling;
    private bool movingright = true;

    //When the alien has come off his path and trys to get back to it
    private bool isLerping = false;

    public float howFarToPatrol = 5f;

    private Vector3 startPosition;
    private Vector3 nextPosition;

    private int speed = 3;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;

    private void Start()
    {
        startPosition = gameObject.transform.position;        
    }

    private void Update()
    {
        if (!isLerping)
        {
            Move();
        }
        

        if (movingright && !isLerping)
        {
            //right
            nextPosition = startPosition + new Vector3(howFarToPatrol, 0f, 0f);

            if (Vector2.Distance(gameObject.transform.position, nextPosition) < 0.5f)
            {
                //Point reached
                ChangeMovement();
            }
        }

        if (!movingright && !isLerping)
        {
            //left
            nextPosition = startPosition + new Vector3(-howFarToPatrol, 0f, 0f);

            if (Vector2.Distance(gameObject.transform.position, nextPosition) < 0.5f)
            {
                //Point reached
                ChangeMovement();
            }

        }

        ///<summary>
        ///awful old code 
        ///future me, laugh when you see this:
        ///Vector3.Distance(gameObject.transform.position, nextPosition) > Vector3.Distance(startPosition + new Vector3(howFarToPatrol, 0f, 0f), startPosition + new Vector3(-howFarToPatrol, 0f, 0f)) || isLerping
        /// </summary>

        //If alien comes off the path
        if (Vector3.Distance(gameObject.transform.position, startPosition) > Vector3.Distance(startPosition, nextPosition) || isLerping)
        {
            LerpToStart();            
        }
    }

    void LerpToStart ()
    {
        isLerping = true;

        rb.velocity = Vector3.zero;
        //Vector3.Lerp(gameObject.transform.position, startPosition, 3f * Time.deltaTime);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startPosition, 3f * Time.deltaTime);

        //If point reached
        if (Vector3.Distance(gameObject.transform.position, startPosition) < 1)
        {
            isLerping = false;

            //The alien moves to the other point instead of trying to reach toe point again it has missed the last Time
            ChangeMovement();
        }
    }

    void Move ()
    {
        //Move the player ba finding the target velocity
        Vector3 targetVelocity = new Vector3(speed, 0f);
        
        //And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);                      
    }

    void ChangeMovement ()
    {
        movingright = !movingright;
        speed *= -1;
    }
}
