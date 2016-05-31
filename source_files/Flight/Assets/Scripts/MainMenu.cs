﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene(1);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
