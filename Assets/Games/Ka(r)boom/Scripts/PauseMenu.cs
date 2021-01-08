using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject scoreUI;
    public GameObject trafficUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        scoreUI.SetActive(true);
        trafficUI.SetActive(true);
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        scoreUI.SetActive(false);
        trafficUI.SetActive(false);
    }
    public void ReLoadGame()
    {
        Resume();
        SceneManager.LoadScene("Actual game");
    }
    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
