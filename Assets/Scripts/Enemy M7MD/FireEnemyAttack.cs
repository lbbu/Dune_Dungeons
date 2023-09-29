using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyAttack : MonoBehaviour
{

    [SerializeField] Transform bulletStartPos;
    [SerializeField] FireEnemyBullets bulletObject;
    [SerializeField] Player player;

    private void Awake()
    {
        if(!player)
            player = FindObjectOfType<Player>();
    }

    public void AddBullet()
    {

        float randomDisplacementX = Random.Range(-1, 1);
        float randomDisplacementZ = Random.Range(-1, 1);

        FireEnemyBullets bullet = Instantiate(bulletObject, bulletStartPos.transform.position, Quaternion.identity);
        bullet.SetTargetPos(new Vector3(player.transform.position.x + randomDisplacementX, 0f, 
            player.transform.position.z + randomDisplacementZ));

        Destroy(bullet, 5f);

    }

}
