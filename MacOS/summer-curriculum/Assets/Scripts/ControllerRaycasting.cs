using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class ControllerRaycasting : MonoBehaviour
{
    /*
    private GameObject rightHand;

    void Start()
    {
        rightHand = GameObject.Find("RightHandAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(rightHand.transform.position, rightHand.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Destroy(hit);
        }
    }
    */

    private GameObject rightHand;

    [HideInInspector]
    public static int score;

    void Start()
    {
        rightHand = GameObject.Find("RightHandAnchor");
        score = 0;
    }

    void Update()
    {
        Ray ray = new Ray(rightHand.transform.position, rightHand.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Destroy(hit.collider.gameObject);
            score++;
        }
    }

}
