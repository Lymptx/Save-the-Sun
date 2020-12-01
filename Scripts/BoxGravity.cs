using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGravity : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerMovement movementScript;

    private void Update()
    {
        if(movementScript.MoonGravityOn)
        {
            //No Gravity
            rb.gravityScale = 0;

        } else if(!movementScript.MoonGravityOn)
        {
            //normal Gravity
            rb.gravityScale = 1;
        }
    }
}
