using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Get the Player transform
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float YCameraOffset = 13f;
        float ZCameraOffset = -2f;

        Vector3 cameraDesiredPosition = new Vector3(0, YCameraOffset, playerTransform.position.z + ZCameraOffset);

        transform.position = cameraDesiredPosition;

    }
}
