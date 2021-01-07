using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordtimer : MonoBehaviour
{
    public Wordmanager wordManager;
    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;
    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
        }
    }
}
