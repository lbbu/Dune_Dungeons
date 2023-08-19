using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to Enemy's health
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Debug.Log("TakeDamag!!!");
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("obstical"))
        {
            Destroy(gameObject);
        }


    }
}

