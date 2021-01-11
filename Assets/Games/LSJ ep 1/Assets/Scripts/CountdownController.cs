using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public ScoreContoller scorre;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "OVER!";

        if (scorre.score < 15)
        {
            Debug.Log("lost");
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose();
        }
        else {
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();
        }
    }
}
