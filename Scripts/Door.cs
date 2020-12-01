using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject myPad;
    private PressurePad PadScript;

    public Animator animator;

    private void Awake()
    {
        PadScript = myPad.GetComponent<PressurePad>();
    }

    private void Update()
    {
        if (PadScript.isDown)
        {
            //Open the door
            animator.SetBool("isOpening", true);
        }

        if (!PadScript.isDown)
        {
            //Open the door
            animator.SetBool("isOpening", false);
        }
    }
}
