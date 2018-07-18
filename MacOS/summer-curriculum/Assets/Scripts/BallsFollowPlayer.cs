using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsFollowPlayer : MonoBehaviour
{
/*
    public float speed;

    private GameObject player;

    // Use this for initialization
    private void Start()
    {
        player = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    */

    public float speed;

    private GameObject player;

    void Start() {
      player = GameObject.Find("Body");
    }

    void Update() {
      float step = speed * Time.deltaTime;

      transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

}
