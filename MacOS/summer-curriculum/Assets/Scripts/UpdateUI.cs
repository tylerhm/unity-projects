using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

/*

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

    */

    private GameObject scoreObject;
    private GameObject healthObject;

    private Text score;
    private Text health;

    void Start() {
      scoreObject = GameObject.Find("Score");
      healthObject = GameObject.Find("Health");

      score = scoreObject.GetComponent<Text>();
      health = healthObject.GetComponent<Text>();
    }

    void Update() {
      health.text = "Health: " + TrackCollisions.health + "%";
      score.text = "Score: " + ControllerRaycasting.score;
    }
}
