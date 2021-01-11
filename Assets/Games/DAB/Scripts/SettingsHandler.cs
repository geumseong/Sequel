using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    public void Difficulty(float difficulty)
    {
        Settings.instance.difficulty = Mathf.RoundToInt(difficulty);
        Debug.Log(Settings.instance.difficulty);
    }

    public void Length(float length)
    {
        Settings.instance.cardstreak = 10 * Mathf.RoundToInt(length);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
