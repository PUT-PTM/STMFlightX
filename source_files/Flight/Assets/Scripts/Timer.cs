using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {


    private float timer = ScoreCount.tim;
    GameObject[] gameover;
    bool showResult = false;
    public static Timer instance;

    public float CurrentTime()
    {
        return timer;
    }

    public void setter(float value)
    {
        timer = value;
    }

    void Start()
    {
        Time.timeScale = 1;
        gameover = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        hideGameOver();
        instance = this;
    }

    void Update () {
        timer -= Time.deltaTime;	
        if(timer<=0)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showGameOver();
                showResult = true;
                OnGUI();
            }

        }

	}

    void OnGUI()
    {
        if (!showResult)
        {
            GUI.Box(new Rect(10, 60, 90, 20), "Time: " + timer.ToString("0"));
        }
        else
        {
            GUI.Label(new Rect(650, 250, 100, 50), "Your result " + ScoreCount.score);
            GUI.Label(new Rect(650, 280, 100, 50), "Press 'm' to return to Main Menu");
            GUI.Label(new Rect(650, 310, 100, 50), "Press 'r' to reload");

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(0);
                ScoreCount.score = 0;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
                ScoreCount.score = 0;
            }
        }
    }

    public void showGameOver()
    {
        foreach (GameObject g in gameover)
        {
            g.SetActive(true);
        }
    }
    public void hideGameOver()
    {
        foreach (GameObject g in gameover)
        {
            g.SetActive(false);
        }
    }

   

}
