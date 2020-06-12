using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance; // makes it a Singleton Pattern. Other scrips use 'instance' to access this script's functions

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1; // of the title panel
    public Text highScore2; // of the game over panel

    void Awake()
    {
        if (instance == null) // if once hasn't been created yet
            instance = this; // makes sure there is only once instance, set to this (first) one
    }

	// Use this for initialization
	void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        tapText.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0); // can pass name of scene or index of scene in build settings
    }
}
