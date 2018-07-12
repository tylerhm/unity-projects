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
        float walk = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        mainCam.transform.position += transform.forward * walk;
    }
}