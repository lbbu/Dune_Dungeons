using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public static Vector3 GetPlayerPos()
    {
        return Instance.transform.position;
    }

}