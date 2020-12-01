using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int maxLives = 5;
    public int lives;

    public Image[] shields;
    public Sprite fullShield;
    public Sprite emptyShield; 

    private void Awake()
    {
        lives = maxLives;
    }

    private void Update()
    {
        if(lives <= 0)
        {
            Die();
        } 

        for (int i = 0; i < shields.Length; i++)
        {
            if (i < lives)
            {
                shields[i].sprite = fullShield;
            } else
            {
                shields[i].sprite = emptyShield;
            }

            if (i < maxLives)
            {
                shields[i].enabled = true;
            } else
            {
                shields[i].enabled = false;
            }
        }
    }

    public void TakeDamage (int damage)
    {
        lives -= damage;
    }

    private void Die ()
    {
        //Die
    }

    private void GetLive()
    {

    }

}
