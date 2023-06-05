using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
