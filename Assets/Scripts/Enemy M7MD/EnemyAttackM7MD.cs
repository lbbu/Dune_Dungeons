using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackM7MD : MonoBehaviour
{

    Collider otherCollider;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        otherCollider = other;

        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Player>())
            otherCollider = null;


    }


    public void MakaDamage()
    {

        if(otherCollider)
        {
            otherCollider.gameObject.GetComponent<PlayerHealth>().TakeDamage(20);
        }

    }


}
