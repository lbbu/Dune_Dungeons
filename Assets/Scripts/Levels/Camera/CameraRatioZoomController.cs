using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRatioZoomController : MonoBehaviour
{
    public float minZoomRatio;
    public float maxZoomRatio;
    public Vector3 minZoom;
    public Vector3 maxZoom;

    void Start()
    {
        FixZoomRatio();   // minZ -31.31437   maxZ -10.51607
    }                     // min X -5.35     maxX 5.93

    void FixZoomRatio()
    {
        float ratio = Screen.width / (float)Screen.height;

        transform.localPosition = Vector3.Lerp(minZoom, maxZoom, Mathf.InverseLerp(minZoomRatio, maxZoomRatio, ratio));
    }
}