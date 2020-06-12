using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	// Use this for initialization
	void Start () {
        gameOver = false;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        UiManager.instance.GameStart();
        //ScoreManager.instance.StartScore(); // may not need to do if do score with every tap
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms(); // only start spawning new platforms when game starts
    }

    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
