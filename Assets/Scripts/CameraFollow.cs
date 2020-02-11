using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 1f;
    public Vector3 offset;

    float upBorder = 30f;

    private void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        if (smoothedPosition.y >= upBorder)
        {
            smoothedPosition = new Vector3(smoothedPosition.x, upBorder, -10);

        }
        transform.position = smoothedPosition;
    }

}