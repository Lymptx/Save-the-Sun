using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public PlayerMovement movement;
    public Animator aniamtor;
    public GameObject Player;
    public GameObject interactText;
    private CharacterController controller;

    public GameObject myPos;

    private bool readyToSwitch = false;

    private void Awake()
    {
        controller = Player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && readyToSwitch)
        {
            Switchi();
        }

        if (Vector2.Distance(myPos.transform.position, Player.transform.position) < 1)
        {
            //Show Text
            interactText.SetActive(true);
            readyToSwitch = true;
        } else if (Vector2.Distance(myPos.transform.position, Player.transform.position) > 1)
        {
            interactText.SetActive(false);
            readyToSwitch = false;
        }
    }  

    private void Switchi ()
    {
        FindObjectOfType<Audio_Manager>().Play_("Switch");

        //Switch to earth mode
        if (movement.MoonGravityOn)
        {
            movement.MoonGravityOn = false;
            aniamtor.SetBool("AnimatorMoonOn", false);

            //Chek for the facing direction
            if(Player.transform.localScale.x < 0)
            {
                //The Players is currently acing left
                controller.facingRight = false;
            } else if (Player.transform.localScale.x > 1)
            {
                //The Player is currently facing right
                controller.facingRight = true;
            }
        }
        else if (!movement.MoonGravityOn) //Switch to MoonMode
        {
            movement.MoonGravityOn = true;
            aniamtor.SetBool("AnimatorMoonOn", true);
        }
    }
}
