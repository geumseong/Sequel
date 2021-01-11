using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memory : MonoBehaviour
{
    public static Memory instance;

    public Sprite cardEmpty;
    public Sprite card1;
    public Sprite card2;
    public Sprite card3;
    public Sprite card4;
    public Sprite card5;
    public Sprite card6;

    public GameObject DisplayedCardObject;
    SpriteRenderer DisplayedCard;

    public List<int> cards = new List<int>();
    public int difficulty;
    public int cardstreak;
    public GameObject buttons;
    public GameObject nextButton;
    public GameObject buttonRestart;
    int turn;
    int score;

    public TextMeshProUGUI whichCardDifficulty;
    public TextMeshProUGUI rememberScore;

    void Awake()
    {
        instance = this;
        DisplayedCard = DisplayedCardObject.GetComponent<SpriteRenderer>();
        score = 0;
        cards.Clear();
        whichCardDifficulty.text= "WHICH CARD WAS DISPLAYED " + difficulty + " CARDS AGO?";
        for (int i = 0; i < cardstreak; i++)
        {
            cards.Add(Random.Range(1, 7));
            //Debug.Log(cards[i]);
        }
        //Debug.Log("----------");
        Display();
        Interact();
    }
    void Display()
    {
        Debug.Log("turn: " + turn);
        if (turn < cardstreak)
        {
            //Debug.Log(cards[turn]);
            switch (cards[turn])
            {
                case 1:
                    DisplayedCard.sprite = card1;
                    break;
                case 2:
                    DisplayedCard.sprite = card2;
                    break;
                case 3:
                    DisplayedCard.sprite = card3;
                    break;
                case 4:
                    DisplayedCard.sprite = card4;
                    break;
                case 5:
                    DisplayedCard.sprite = card5;
                    break;
                case 6:
                    DisplayedCard.sprite = card6;
                    break;
                default:
                    break;
            }
        }
        else
        {
            DisplayedCard.sprite = cardEmpty;
        }
    }
    void Interact()
    {
        if (turn < difficulty)
        {
            buttons.SetActive(false);
            nextButton.SetActive(true);
            buttonRestart.SetActive(false);
            Debug.Log("press Next");
            whichCardDifficulty.text = ("you'll have to remember this spaceship in 2 turns");
        }
        else if (turn < cardstreak + difficulty)
        {
            buttons.SetActive(true);
            nextButton.SetActive(false);
            buttonRestart.SetActive(false);
            //Debug.Log("1-6");
            whichCardDifficulty.text = ("which spaceship was displayed 2 turns ago?");
        }
        else
        {
            rememberScore.text = "Final Score: " + score + "/" + cardstreak;
            whichCardDifficulty.text = ("");

            if (score < 5)
                GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose();
            else
                GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();

            buttons.SetActive(false);
            nextButton.SetActive(false);
            //buttonRestart.SetActive(true);
            Debug.Log("GameOver");
        }
    }
    public void Compute(int selectedCard)
    {
        Debug.Log(selectedCard);
        if (selectedCard == cards[turn - difficulty])
        {
            Debug.Log("Correct");
            score++;
        }
        else
        {
            Debug.Log("Incorrect");
        }
        turn++;
        //Debug.Log("turn: " + turn);
        Display();
        Interact();
    }
    public void Next()
    {
        turn++;
        //Debug.Log("turn: " + turn);
        Display();
        Interact();
    }
    /*private void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            turn++;
            Debug.Log("turn: " + turn);
            Display();
            Interact();
        }
        if (Input.GetKeyDown("d"))
        {
            Debug.Log("answer: " + cards[turn-difficulty]);
        }
        if (Input.GetKeyDown("1"))
        {
            Compute(1);
        }
        if (Input.GetKeyDown("2"))
        {
            Compute(2);
        }
        if (Input.GetKeyDown("3"))
        {
            Compute(3);
        }
        if (Input.GetKeyDown("4"))
        {
            Compute(4);
        }
        if (Input.GetKeyDown("5"))
        {
            Compute(5);
        }
        if (Input.GetKeyDown("6"))
        {
            Compute(6);
        }
    }*/
}
