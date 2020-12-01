using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    public int rotationSpeed = 1000;
    public int scaleSpeed = 100;

    public bool isScaling = false;
    private bool isCompletingLevel = false;

    public GameObject player;
    public PlayerMovement movementScript;
    public GameObject notAvaiableText;

    public GameObject gameManagerObject;
    private GameManager gameManagerScript;

    private void Awake()
    {
        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
    }


    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


        if (Vector2.Distance(transform.position, player.transform.position) < 1f)
        {
             //Win Level and Scale up
            isScaling = true;
        }

        //} else if (movementScript.MoonGravityOn)
        //{
        //    //Dislpay Text
        //    notAvaiableText.SetActive(true);
        //}

        if (isScaling)
        {
            Vector3 scaleChange = new Vector3(Time.deltaTime * scaleSpeed, Time.deltaTime * scaleSpeed, 0f);
            transform.localScale += (scaleChange);

        }

        if (isScaling)
        {
            if(!isCompletingLevel)
            {
                isCompletingLevel = true;
                StartCoroutine("FinishLevel");
            }            
        }


    }

    IEnumerator FinishLevel ()
    {
        yield return new WaitForSeconds(0.8f);  
        gameManagerScript.CompleteLevel();
    }
    
}
