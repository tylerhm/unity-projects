using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{

    public float speed;

    void Update()
    {
        float walk = (OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad)).y * Time.deltaTime * speed;
        transform.Translate(0.0f, 0.0f, walk);
    }
}
