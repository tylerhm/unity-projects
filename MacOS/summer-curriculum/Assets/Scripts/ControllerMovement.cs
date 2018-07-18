using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    /*
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
    */

    public float speed;
    private GameObject mainCam;

    void Start()
    {
        mainCam = GameObject.Find("OVRCameraRig");
    }

    void Update()
    {
        float walkV = (OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad)).y * Time.deltaTime * speed;
        mainCam.transform.position += new Vector3(0, 0, 1) * walkV;

        float walkH = (OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad)).x * Time.deltaTime * speed;
        mainCam.transform.position += new Vector3(1, 0, 0) * walkH;
    }
}