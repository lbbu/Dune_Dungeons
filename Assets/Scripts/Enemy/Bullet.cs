using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Force = 100;
    public Rigidbody rb;
    //public GameObject Effect;

    void Start()
    {
        rb.velocity = transform.forward * Force;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

    }
}

