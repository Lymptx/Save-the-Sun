using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    private GameObject Player;
    private PlayerLives playerLives;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerLives = Player.GetComponent<PlayerLives>();

        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            playerLives.TakeDamage(1);
        }

        Debug.Log(hitInfo.name);        
        Destroy(gameObject);
    }

}
