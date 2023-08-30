using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FacingEnemy : MonoBehaviour
{
    //face Target Values
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] GameObject AllEnemys;
    [SerializeField] float sightRange = 14f;
    bool isFacingEnemy = false;
    Transform closestEnemy;
    int num;
    List<Transform> nearbyEnemies = new List<Transform>();
    float detectionRange = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (!GetComponent<PlayerMovements>().IsWalking())
        {
            UpdateNearbyEnemies();
            if (closestEnemy != null)
            {

                distanceToTarget = Vector3.Distance(closestEnemy.position, transform.position);
                faceTarget();
            }

        }

        
        
    }
    void UpdateNearbyEnemies()
    {
        nearbyEnemies.Clear();

        foreach (Transform enemy in AllEnemys.transform) // Make sure to use Enemy.transform to access child transforms
        {
            float distance = Vector3.Distance(enemy.position, transform.position);
            if (distance <= detectionRange)
            {
                nearbyEnemies.Add(enemy);
            }
        }

        FindClosestEnemy();
    }
    void faceTarget()
        {
            // num =   getRandomNumber();
            if (distanceToTarget <= sightRange)
            {
                isFacingEnemy = true;
                Vector3 direction = (closestEnemy.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6);
            }
        }

        void FindClosestEnemy()
        {
            float closestDistance = Mathf.Infinity;
            closestEnemy = null;

            foreach (Transform enemy in AllEnemys.transform)
            {
                float distance = Vector3.Distance(enemy.position, transform.position);
                if (distance < closestDistance && distance <= sightRange)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

    public bool GetIsEmptyListOfEnemys()
    {
        if (nearbyEnemies.Count == 0)
            return true;
        return false;
    }
}
