using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool MoonGravityOn = false;

    public CharacterController controller;
    public MoonController moonControlelr;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject gameManagerObject;
    private GameManager gameManagerScript;
        
    public float runSpeed = 40;
    public float moonSpeed = 40;
    float horizontalMove = 0;
    float verticalMove = 0;
    bool jump = false;

    private void Awake()
    {
        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!MoonGravityOn)
        {
            rb.gravityScale = 3;            
        }
        else if (MoonGravityOn)
            rb.gravityScale = 0;

        
       if (animator.GetBool("jetpack") != MoonGravityOn)
        {
            animator.SetBool("jetpack", !animator.GetBool("jetpack"));
        }

        


        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        
        if (MoonGravityOn == false)
        {               

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }

            //Set the velocity in the aminator
            animator.SetFloat("Y_Velovity", rb.velocity.y);

            if (rb.velocity.y < 0)
            {
                animator.SetBool("isJumping", false);
            }
        }

        if (!MoonGravityOn)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
            {
                //Moving
                animator.SetBool("running", true);
            }
            else
                animator.SetBool("running", false);

        }

        if(rb.position.y < -50)
        {          

            //End Level
            gameManagerScript.EndLevel();
        }

    }

    public void OnLanding () 
    {
        animator.SetBool("isJumping", false);
        Debug.Log("Landed");
    }
    
    private void FixedUpdate()
    {
        if (MoonGravityOn == false)
        {
            //Move the player
            controller.Move(horizontalMove * Time.deltaTime * runSpeed, jump);
            jump = false;

        } 
        else if (MoonGravityOn == true)
        {
            moonControlelr.MoonMove(horizontalMove * Time.deltaTime * moonSpeed, verticalMove * Time.deltaTime * moonSpeed);
        }

    }
}
