using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;

    [SerializeField]
    private float speed; // speed of ball
    [SerializeField]
    private float fallSpeed; // speed ball falls off platform at
    bool started; // keep track when game has started, which is when player first taps screen
    bool gameOver; // ball falls off of platform
    Rigidbody rb;

    // Use for anything happening before Start()
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        started = false; // game has not started yet / screen not touched / mouse not clicked 
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0); // ball will only move in x direction
                started = true;

                GameManager.instance.GameStart(); // GameManager controls start of game
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f)) // if raycast not hitting anything / ball falling off
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -fallSpeed, 0);
            Destroy(gameObject, 1.0f);

            Camera.main.GetComponent<CameraFollow>().gameOver = true; // access gameOver variable in camera scripts, assign to true.

            GameManager.instance.GameOver(); // GameManager controls end of game
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirections();
            ScoreManager.instance.IncrementScore();
        }
	}

    void SwitchDirections()
    {
        if (rb.velocity.z > 0)
            rb.velocity = new Vector3(speed, 0, 0);
        else if (rb.velocity.x > 0)
            rb.velocity = new Vector3(0, 0, speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 1.0f);
            ScoreManager.instance.DiamondScore();
             
        }
    }
}
