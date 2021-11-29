using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused ;
    public GameObject pauseMenu;
    private void Awake() {
      GamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void QuitGame()
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene("Start");
    }
    public void RestGame()
    {
      Time.timeScale = 1f;      
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
