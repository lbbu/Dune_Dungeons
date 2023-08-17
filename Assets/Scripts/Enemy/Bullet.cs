using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Force = 100;
    public Rigidbody rb;
    [SerializeField] int damage = 10;




    void Start()
    {
        rb.velocity = transform.forward * Force;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to player's health
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

       if(collision.gameObject.CompareTag("obstical"))
        {
            Destroy(gameObject);
        }
        

    }
}

