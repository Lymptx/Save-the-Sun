using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;

    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;

    private Vector3 m_Velocity = Vector3.zero;

    [SerializeField] private float m_JumpForce = 400f;     

    public bool facingRight = true;
    private bool isGrounded;

    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private Transform GroundCheck;
    const float GroundedRadius = .2f;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }


    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;

                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        //When changing to moonMode while facing left this bool is flipped
        if(transform.localScale.x > 0)
        {
            facingRight = true;
        }

    }

    public void Move(float move, bool jump)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);

        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);


        // If the player should jump...
        if (isGrounded && jump)
        {
            // Add a vertical force to the player.
            isGrounded = false;
            rb.AddForce(new Vector2(0f, m_JumpForce));
        }


        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }



    private void Flip()
    {
        //Switch the facingRight bool
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
