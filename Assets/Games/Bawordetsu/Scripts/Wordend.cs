using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordend : MonoBehaviour
{
    Worddisplay display;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Word")) 
        { 
            Debug.Log("lifelost");
            Gamemanager.lives--;
            display = other.GetComponent<Worddisplay>();
            display.RemoveWord();
        }
    }
}
