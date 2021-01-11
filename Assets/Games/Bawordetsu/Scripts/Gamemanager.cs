using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Gamemanager 
{
    private static Gamemanager instance;
    public static int lives;
    public static int score;

    public static Gamemanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Gamemanager();
            }
            return instance;
        }
    }
    public static void Combo(int combo)
    {
        switch (combo)
        {
            case 1:
                score += 200;
                break;
            case 2:
                Debug.Log("Good!");
                score += 500;
                break;
            case 3:
                Debug.Log("Nice!");
                score += 900;
                break;
            case 4:
                Debug.Log("Wow!");
                score += 1400;
                break;
            case 5:
                Debug.Log("YES!");
                score += 2000;
                break;
            default:
                break;
        }
    }
}
