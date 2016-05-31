using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    public float timer = 120;
    GameObject[] gameover;
    bool showResult = false;

    void Start()
    {
        Time.timeScale = 1;
        gameover = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        hideGameOver();
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
            timer = 0;
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
            GUI.Label(new Rect(650, 200, 100, 50), "Your result " + ScoreCount.score);
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
