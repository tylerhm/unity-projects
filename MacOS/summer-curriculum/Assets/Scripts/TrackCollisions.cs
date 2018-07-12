using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollisions : MonoBehaviour
{
    [HideInInspector]
    public static int health;

    private void Start()
    {
        health = 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider);
        health -= 10;
    }
}
