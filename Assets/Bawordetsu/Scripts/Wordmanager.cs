using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Wordmanager : MonoBehaviour
{
    public List<Word> words;
    public Wordspawner wordspawner;
    public GameObject wordobject;
    public static Wordmanager Instance;
    public int combocounter;
    Word deleteme=null;
    Word deleteme2 = null;
    Word deleteme3 = null;
    Word deleteme4 = null;
    bool deletable;
    AudioSource explosion;
    public CameraScript cameras;
    public void Start()
    {
        Instance = this;
        explosion = GetComponent<AudioSource>();
    }

    public void AddWord()
    {
        Word word = new Word(Wordgenerator.GetRandomWord(), wordspawner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
        word.display.index = words.IndexOf(word);
        //Debug.Log("new word with index " + word.display.index);
    }

    public void TypeLetter(char letter)
    {
        Debug.Log("WHY");
        foreach(Word word in words)
        {
            //Debug.Log("whyme");
            if (word.WordTyped() == false)
            {
                if (word.GetNextLetter() == letter)
                {
                    //Debug.Log("Char");
                    word.TypeLetter();
                    if (word.WordTyped() == true)
                    {
                        //Debug.Log("somethingtobeyeeted");  
                        deletable = true;
                        if (deleteme == null)
                        {
                            deleteme = word;
                            //Debug.Log("added");
                        }
                        else if (deleteme2 == null)
                        {
                            deleteme2 = word;
                        }
                        else if (deleteme3 == null)
                        {
                            deleteme3 = word;
                        }
                        else if (deleteme4 == null)
                        {
                            deleteme4 = word;
                        }
                    }
                    combocounter++;
                }
            }
        }
        if (deletable == true)
        {
            deleteme.display.RemoveWord();
            deleteme = null;
            if (deleteme2!=null)
            {
                deleteme2.display.RemoveWord();
                deleteme2 = null;
            }
            if (deleteme3 != null)
            {
                deleteme3.display.RemoveWord();
                deleteme3 = null;
            }
            if (deleteme4 != null)
            {
                deleteme4.display.RemoveWord();
                deleteme4 = null;
            }
            deletable = false;
        }
        Gamemanager.Combo(combocounter);
        for(int i=combocounter; i > 1; i--)
        {
            words[0].display.RemoveWord();
        }
        if (combocounter > 1) 
        {
        StartCoroutine(cameras.Shake(.5f, .15f, combocounter));
            explosion.Play();
        }
        combocounter = 0;
    }
}
