using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    float preSpeed;
    PlayerMovements player;

    [SerializeField] float PowerUpSpeed = 11;
    [SerializeField] float PowerUpTime = 1.75f;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
         player = other.GetComponent<PlayerMovements>();
          StartCoroutine(EditSpeed(player));
        }
    }

   


   IEnumerator EditSpeed(PlayerMovements player)
    {
        preSpeed = player.GetMoveSpeed();
        player.SetMoveSpeed(PowerUpSpeed);
        Transform childTransform = transform.Find("body");
        Destroy(childTransform.gameObject);
        yield return new WaitForSeconds(PowerUpTime);
        player.SetMoveSpeed(preSpeed);
        Destroy(gameObject);
    }
}
