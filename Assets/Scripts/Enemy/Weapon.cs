using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;
    [SerializeField] float StartShootDistance = 7f;

    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject bullet;

   [SerializeField] EnemyFollowPlayer player;

    float nextShootTime;
    bool isReloading;

    void Update()
    {
        if (CanShoot())
        {
          shoot(); 
        }
        
    }

    private void shoot()
    { 
        nextShootTime = Time.time + 1 / fireRate;
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        
    }

    bool CanShoot()
    {
        return
            Time.time >= nextShootTime &&
            isReloading == false && player.DistanceToTarget() <= StartShootDistance;
    }
}
