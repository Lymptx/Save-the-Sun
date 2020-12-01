using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    //Settings
    [Header("Settings")]
    public bool inverseDoor;
    public bool closeInMoonMode;
    public bool closeInEarthMode;
    public bool openInMoonMode;
    public bool openInEarthMode;
    public bool startOpen;

    private bool OldIsMoonGravity = false;

    public Animator animator;
    public bool isDown = false;
    public GameObject Player;
    private PlayerMovement movementScript;

    private void Awake()
    {
        movementScript = Player.GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        if (!inverseDoor)
        {
            if (!startOpen)
            {
                Open();
                //Open and closed is reversed somehow I think
            } else if (startOpen)
            {
                Close();
            }
        }
        else if (inverseDoor)
        {
            //Open and closed is reversed somehow I think
            Close();
        }
    }

    private void Update()
    {
        if(movementScript.MoonGravityOn != OldIsMoonGravity)
        {
            Debug.Log("LOLOLOLO"); //Wird aufgerufen
            GravityHasChanged(movementScript.MoonGravityOn);
            OldIsMoonGravity = movementScript.MoonGravityOn;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {

            if (!inverseDoor)
            {
                Close();
                FindObjectOfType<Audio_Manager>().Play_("DoorOpen");

            } else if (inverseDoor)
            {
                Open();
                FindObjectOfType<Audio_Manager>().Play_("DoorClose");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!inverseDoor)
        {
            Open();
            FindObjectOfType<Audio_Manager>().Play_("DoorClose");
        }
        else if (inverseDoor)
        {
            Close();
            FindObjectOfType<Audio_Manager>().Play_("DoorOpen");
        }
    }

    private void Open()
    {
        animator.SetBool("PadIsUp", true);
        isDown = false;        

    }

    private void Close()
    {
        animator.SetBool("PadIsUp", false);
        isDown = true;
        
    }

    void GravityHasChanged(bool newGravity)
    {
         
        if (newGravity && closeInMoonMode)
        {
            //The new gravity is moon and door should close
            //Open and closed is reversed somehow I think
            Open();
        }

        if (!newGravity && closeInEarthMode)
        {
            //The new gravity is earth and door should close
            //Open and closed is reversed somehow I think
            Open();
        }

        if (newGravity && openInMoonMode)
        {
            //The new gravity is moon and door should open
            //Open and closed is reversed somehow I think
            Close();
            
        }

        if (!newGravity && openInEarthMode)
        {
            //The new gravity is moon and door should close
            //Open and closed is reversed somehow I think
            Close();
            Debug.Log("PLSSSSS");
        }
    }
}
