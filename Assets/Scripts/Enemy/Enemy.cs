using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] EnemyHealth enemyHealth;

    
    private void Update()
    {
        HandleEnemyDeath();
    }

    private void HandleEnemyDeath()
    {
        
        if (enemyHealth.IsDead())
        {
            Debug.Log("Dead!");
            Destroy(gameObject);
            ScoreManager.Instance.IncrementScore();

        }
    }
}
