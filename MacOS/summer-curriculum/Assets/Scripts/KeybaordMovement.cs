using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    public float speed;

    void Update()
    {
        float walk = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0.0f, 0.0f, walk);
    }
}