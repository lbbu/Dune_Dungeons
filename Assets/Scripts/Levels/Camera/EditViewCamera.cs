using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditViewCamera : MonoBehaviour
{
    public float referenceWidth = 1080f; // The reference screen width (in pixels) for which the camera view is designed.
    public float referenceHeight = 1920f; // The reference screen height (in pixels) for which the camera view is designed.
    public float fieldOfView = 60f; // The desired field of view.

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // Calculate the aspect ratio of the reference resolution.
        float referenceAspect = referenceWidth / referenceHeight;

        // Calculate the current aspect ratio.
        float currentAspect = (float)Screen.width / Screen.height;

        // Calculate the desired camera size based on the reference FOV and current aspect ratio.
        float desiredSize = Mathf.Atan(Mathf.Tan(fieldOfView * Mathf.Deg2Rad / 2f) / currentAspect) * 2f * Mathf.Rad2Deg;

        // Set the camera's field of view to the desired size.
        mainCamera.fieldOfView = desiredSize;

        // Optionally, you can also adjust other camera settings such as position, rotation, etc.
    }
}
