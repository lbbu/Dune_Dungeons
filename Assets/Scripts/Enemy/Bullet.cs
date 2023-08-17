using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Force = 100;
    public Rigidbody rb;


    void Start()
    {
        rb.velocity = transform.forward * Force;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        Destroy(gameObject);
    }
}

