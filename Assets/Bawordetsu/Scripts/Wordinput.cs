using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordinput : MonoBehaviour
{
    public ScoreUI scoreui;
    public Wordmanager wordManager;
    void Update()
    {
        if (!scoreui.paused&&!scoreui.gameend) 
        { 
            foreach (char letter in Input.inputString)
            {
                wordManager.TypeLetter(letter);
                Debug.Log(letter);
            }
        }
    }
}
