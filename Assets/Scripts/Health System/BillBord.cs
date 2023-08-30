using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBord : MonoBehaviour
{

    //this code makes the health bar looks at the camera

    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        if(!mainCamera)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}
