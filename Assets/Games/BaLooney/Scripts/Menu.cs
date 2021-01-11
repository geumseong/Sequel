using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void ReStartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
