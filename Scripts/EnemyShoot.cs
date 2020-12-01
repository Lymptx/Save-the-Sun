using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 1f);
    }

    void Shoot ()
    {
        // shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  
    }

}
