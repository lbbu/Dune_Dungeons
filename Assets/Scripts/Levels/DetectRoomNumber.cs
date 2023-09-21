using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRoomNumber : MonoBehaviour
{

    Player player;
    [SerializeField] int currentRoomNum;


    private  void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player  = collision.gameObject.GetComponent<Player>();
            player.SetDetectdRoomNumber(currentRoomNum);
        }
    }
}
