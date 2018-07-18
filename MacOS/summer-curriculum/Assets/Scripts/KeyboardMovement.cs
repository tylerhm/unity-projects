using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    public float speed;
    private GameObject mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("OVRCameraRig");
    }

    void Update()
    {
        float walkV = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        mainCam.transform.position += new Vector3(0, 0, 1) * walkV;

        float walkH = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        mainCam.transform.position += new Vector3(1, 0, 0) * walkH;
    }
}