using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex >= 6)
        {
            int score = PlayerPrefs.GetInt("GemScore", 0);
            Cursor.visible = true;
            if (isPaused)
            {

            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        FindObjectOfType<AudioManager>().Pause("bg1");
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        FindObjectOfType<AudioManager>().UnPause("bg1");
    }

    public void ResumeDefault()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        FindObjectOfType<AudioManager>().UnPause("bg1");
    }

    public void Menu()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Application.Quit();
    }

}
