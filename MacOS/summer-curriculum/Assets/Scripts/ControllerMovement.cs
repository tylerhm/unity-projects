using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{

    public float speed;
    private GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("OVRCameraRig");
    }

    void Update()
    {
        float walk = (OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad)).y * Time.deltaTime * speed;
        mainCam.transform.position += transform.forward * walk;
    }
}
