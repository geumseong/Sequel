using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordend : MonoBehaviour
{
    AudioSource error;
    Worddisplay display;
    public void Start()
    {
        error=GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Word")) 
        { 
            Debug.Log("lifelost");
            Gamemanager.lives--;
            display = other.GetComponent<Worddisplay>();
            display.RemoveWord();
            error.Play();
        }
    }
}
