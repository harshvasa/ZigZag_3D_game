using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public int highScore;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    // Use this for initialization
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score); // "score" is our key, score is value stored in key
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void IncrementScore()
    {
        score += 1;
    }

    public void DiamondScore()
    {
        score += 2;
    }

  /* public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }*/

    public void StopScore()
    {
       // CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score); // set it one final time at the end

        if (PlayerPrefs.HasKey("highScore")) // if there is already a highScore key created
        {
            if(score > PlayerPrefs.GetInt("highScore")) // if player score is higher than their highScore
            {
                PlayerPrefs.SetInt("highScore", score); // set highScore key to current score
            }
        }
        else // create highScore key and set their score as it.
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
