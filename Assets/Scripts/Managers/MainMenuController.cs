using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Author: Jacob Todasco
Student #: 301251200
Date Modified: 01/29/2023
Description: Main Menu behavior
*/

public class MainMenuController : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStart()
    {
        //Not Functional yet
    }

    public void Options() 
    {
        //Not Functional yet
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }


}
