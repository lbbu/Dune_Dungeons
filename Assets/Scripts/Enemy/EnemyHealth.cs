using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] int healthPoints = 10;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
     
    public void loseHealth(int WeaopnDamage)
    {
        healthPoints -= WeaopnDamage;
        if(healthPoints < 0) 
        {
            isDead = true;
        }
    }
}
