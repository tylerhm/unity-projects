using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{

    /*

    [HideInInspector]
    public static int ballCount;
    public int maxBalls;

    private Vector3 position;

    private float xPos;
    private float zPos;

    public float spawnDelay;
    private float timeBuffer;

    public GameObject ball;

    // Use this for initialization
    void Start()
    {
        ballCount = 0;
        timeBuffer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if ((ballCount <= maxBalls) && (Time.time > timeBuffer))
        {
            xPos = transform.position.x;
            zPos = transform.position.z;

            position = new Vector3(Random.Range(xPos - 20, xPos + 20), 0.5f, Random.Range(zPos - 20, zPos + 20));
            Instantiate(ball, position, Quaternion.identity);

            ballCount++;
            timeBuffer += spawnDelay;
        }
    }

    */

    [HideInInspector]
    public static int ballCount;
    public int maxBalls;

    private Vector3 bPosition;

    private float xPos;
    private float zPos;

    public float spawnDelay;
    private float timeBuffer;

    public GameObject ball;

    void Start()
    {
        ballCount = 0;
        timeBuffer = spawnDelay;
    }

    void Update()
    {
        if ((ballCount < maxBalls) && (Time.time > timeBuffer))
        {
            xPos = transform.position.x;
            zPos = transform.position.z;

            bPosition = new Vector3(Random.Range(xPos - 20, xPos + 20), 0.5f, Random.Range(zPos - 20, zPos + 20));
            Instantiate(ball, bPosition, Quaternion.identity);

            ballCount++;
            timeBuffer += spawnDelay;
        }
    }
}
