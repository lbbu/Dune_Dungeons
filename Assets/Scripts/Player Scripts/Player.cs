using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    [SerializeField]   int RoomNumber = 1;

    private void Awake()
    {
        Instance = this;
    }

    public static Vector3 GetPlayerPos()
    {
        return Instance.transform.position;
    }

    public  void SetDetectdRoomNumber(int CurrentRoomNum)
    {
        RoomNumber = CurrentRoomNum;
    }

    public int GetDetectdRoomNumber()
    {
       return RoomNumber;
    }
}