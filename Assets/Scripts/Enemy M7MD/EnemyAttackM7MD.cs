using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackM7MD : MonoBehaviour
{

    PlayerHealth playerHealth;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();



    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerHealth>())
            playerHealth = null;

    }


    public void MakaDamage()
    {

       if(playerHealth != null)
        {
            playerHealth.TakeDamage(20);
        }
    }


}
