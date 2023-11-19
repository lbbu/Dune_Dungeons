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
    public Transform closestEnemy;
    int num;
     public List<Transform> nearbyEnemies = new List<Transform>();
    public float detectionRange = 10f;
    [SerializeField] Player player;
    void Start()
    {
        player = GetComponent<Player>();
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

        int i = player.GetDetectdRoomNumber();
       
        foreach (Transform enemy in AllEnemys.transform) // Make sure to use Enemy.transform to access child transforms
        {
            float distance = Vector3.Distance(enemy.position, transform.position);
            
                nearbyEnemies.Add(enemy);
            
        }

        FindClosestEnemy();
    }
    void faceTarget()
        {
            // num =   getRandomNumber();
            
                isFacingEnemy = true;
                Vector3 direction = (closestEnemy.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 6);
            
        }

        void FindClosestEnemy()
        {
            float closestDistance = Mathf.Infinity;
            closestEnemy = null;
        int i = player.GetDetectdRoomNumber();

        foreach (Transform enemy in AllEnemys.transform)
            {
                float distance = Vector3.Distance(enemy.position, transform.position);
                if (distance < closestDistance && distance <= detectionRange)
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
