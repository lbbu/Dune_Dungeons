using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class FilmSwitchCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] CurrentCM;
    int Current_CM_Index = 0;
    int Pre_CM_Index = 0;

    void Start()
    {
        CurrentCM[Current_CM_Index].gameObject.SetActive(true);

    }

    void Update()
    {
        Pre_CM_Index = Current_CM_Index;
        
        if ( Input.GetKeyDown(KeyCode.V))
        {
            if(Current_CM_Index >= CurrentCM.Length-1) { Current_CM_Index = 0; } else
            Current_CM_Index++;

            CurrentCM[Pre_CM_Index].gameObject.SetActive(false);
            CurrentCM[Current_CM_Index].gameObject.SetActive(true);
        }
    }
}
