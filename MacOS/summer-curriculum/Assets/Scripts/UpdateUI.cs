using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    private GameObject healthObject;
    private GameObject scoreObject;

    private Text health;
    private Text score;

    // Use this for initialization
    void Start()
    {
        healthObject = GameObject.Find("Health");
        scoreObject = GameObject.Find("Score");

        health = healthObject.GetComponent<Text>();
        score = scoreObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + TrackCollisions.health + "%";
        score.text = "Score: " + DestroyBalls.score;
    }
}
