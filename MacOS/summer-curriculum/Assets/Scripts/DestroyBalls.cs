using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

public class DestroyBalls : MonoBehaviour
{

    private GameObject rightHand;

    [HideInInspector]
    public static int score;

    void Start()
    {
        rightHand = GameObject.Find("RightHandAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(rightHand.transform.position, rightHand.transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == "ball")
        {
            Destroy(hit.collider.gameObject);
            score++;
        }
    }
}