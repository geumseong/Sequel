using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public float time = 0f;
    public TextMeshProUGUI Scoretext;
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI WinUI;
    public TextMeshProUGUI LoseUI;
    public TextMeshProUGUI PauseUI;
    public TextMeshProUGUI EndTimeUI;
    public bool paused;
    public bool gameend;
    string minutes;

    private void Awake()
    {
        Gamemanager.lives = 3;
        Gamemanager.score = 0;
    }
    void Update()
    {
        Scoretext.text = ("Score: " + Gamemanager.score);
        Lives.text = (Gamemanager.lives + " lives");
        time += Time.deltaTime;
        minutes = ((time % 3600) / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        Timer.text = minutes + ":" + seconds;
        if (Gamemanager.lives <= 0)
        {
            Debug.Log("lose");
            Lose();
        }
        if (time >= 30)
        {
            Debug.Log("lose");
            Lose();
        }
        if (Gamemanager.score >= 10000)
        {
            Debug.Log("win");
            Win();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("lose");
            Lose();
        }
    }
    void Pause()
    {
        PauseUI.gameObject.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }
    void Resume()
    {
        PauseUI.gameObject.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }
    void Win()
    {
        //WinUI.gameObject.SetActive(true);
        //EndTimeUI.text = (minutes + ":" + time.ToString());
        //EndTimeUI.gameObject.SetActive(true);
        time = 0;
        gameend = true;
        GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();
    }
    void Lose()
    {
        //LoseUI.gameObject.SetActive(true);
        gameend = true;
        Timer.text = ("try again");
        GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose();
    }
}
