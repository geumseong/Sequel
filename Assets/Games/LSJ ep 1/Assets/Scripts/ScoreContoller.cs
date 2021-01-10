using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContoller : MonoBehaviour
{
    public int score;

    public GameObject scoreText;
   
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUp()
    {
        score++;
        scoreText.GetComponent<Text>().text = "Score: " + score;

        if (score >= 10)
        {
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();

        }
    }
}
