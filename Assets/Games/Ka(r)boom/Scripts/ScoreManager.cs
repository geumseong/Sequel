using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
    int lives;
    int carCount;
    int carDesCount;
    public GameObject scoreTextObj;
    public GameObject scoreTextObj2;
    public GameObject livesTextObj;
    public GameObject carCountTextObj;
    public GameObject GameOver;
    public GameObject CarDestroyedTextObj;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreTextObj.GetComponent<Text>().text = "Score : " + score;
        lives = 5;
        livesTextObj.GetComponent<Text>().text = "Lives : " + lives;
        carCount = 2;
        carCountTextObj.GetComponent<Text>().text = "Car Count : " + carCount;
        carDesCount = 0;
        CarDestroyedTextObj.GetComponent<Text>().text = "Car Destroyed : " + carDesCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void carDestroyedCount() {
        carDesCount = carDesCount + 1;
        CarDestroyedTextObj.GetComponent<Text>().text = "Car Destroyed : " + carDesCount;
    }

    public void IncreaseScore() {
        score = score + 5;
        scoreTextObj.GetComponent<Text>().text = "Score : " + score;
        scoreTextObj2.GetComponent<Text>().text = "Score : " + score;
    }
    public void DecreaseLives() {
        lives = lives - 1;
        livesTextObj.GetComponent<Text>().text = "Lives : " + lives;
        // if lives becomes 0 -> Timscale 0 + Activate GameOverScreen
        if(lives == 0)
        {
            GameOver.SetActive(true);
            GameObject.Find("TrafficLightButtons").SetActive(false);
            GameObject.Find("ScoreUI").SetActive(false);
        }
    }
    public void CarCountUp() {
        carCount = carCount + 1;
        carCountTextObj.GetComponent<Text>().text = "Car Count : " + carCount;
        // if carcount becomes 10 -> Timscale 0 + Activate GameOverScreen
        if (carCount == 10)
        {
            GameOver.SetActive(true);
            GameObject.Find("TrafficLightButtons").SetActive(false);
            GameObject.Find("ScoreUI").SetActive(false);
        }
    }
    public void CarCountDown() {
        carCount = carCount - 1;
        carCountTextObj.GetComponent<Text>().text = "Car Count : " + carCount;
    }
}
