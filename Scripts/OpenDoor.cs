using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{    
    //Positions
    private Vector2 startPos;
    private Vector2 openPos;
    private Vector2 newPosition;

    public Transform HidePos;

    //Pressure Pad
    public GameObject myPad;
    private PressurePad PadScript;
    public PlayerMovement movementScript;

    //Variables
    public float OpenTime = 2;
    public bool closed = true;
       

    private void Awake()
    {
        startPos = transform.position;
        openPos = HidePos.position;
        //Get Pad Script
        PadScript = myPad.GetComponent<PressurePad>();
    }

    private void Update()
    {                    

        if(PadScript.isDown)
        {
            //Open the door
            closed = false;

        } else if(!PadScript.isDown)
        {
            //Close the door
            closed = true;
        }


        PositionChange();       
        
    }

    void PositionChange ()
    {
        if(closed)
        {
            newPosition = startPos;
        } else
        {
            newPosition = openPos;
        }

        transform.position = Vector2.Lerp(transform.position, newPosition, Time.deltaTime * OpenTime);
    }

    
}
