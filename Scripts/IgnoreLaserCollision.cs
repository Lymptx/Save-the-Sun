using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLaserCollision : MonoBehaviour
{
    public GameObject laserCollider;

    private void Awake()
    {
        Physics2D.IgnoreCollision(laserCollider.GetComponent<EdgeCollider2D>(), GetComponent<BoxCollider2D>());
    }
}
