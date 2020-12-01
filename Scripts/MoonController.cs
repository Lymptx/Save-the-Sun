using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{
    public Rigidbody2D rb;

    public PlayerMovement playerMovementScript;

    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
     

    public void MoonMove(float horizontalMove, float verticalMove)
    {
        //Move the player ba finding the target velocity
        Vector3 targetVelocity = new Vector3(horizontalMove * 10f, verticalMove * 10f);

        //And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);

        // If the input is moving the player right
        if (horizontalMove > 0)
        {
            FlipToRight();
        }

        if (horizontalMove < 0)
        {
            FlipToLeft();
        }

        //// If the input is moving the player right and the player is facing left...
        //if (horizontalMove > 0 && !facingRight)
        //{
        //    // ... flip the player.
        //    Flip();
        //}
        //// Otherwise if the input is moving the player left and the player is facing right...
        //else if (horizontalMove < 0 && facingRight)
        //{
        //    // ... flip the player.
        //    Flip();
        //}
    }

    //private void Flip ()
    //{
    //    //Switch the facingRight bool
    //    facingRight = !facingRight;

    //    // Multiply the player's x local scale by -1.
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}
    private void FlipToRight()
    {
        transform.localScale = new Vector3 (1f, 1f, 1f);
    }

    private void FlipToLeft()
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }


}
