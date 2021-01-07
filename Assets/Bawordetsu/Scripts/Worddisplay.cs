using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Worddisplay : MonoBehaviour
{
    public Wordmanager wordmanager;
    public Word word;
    public float fallSpeed = 1f;
    public Text text;
    public int index;
    public int indextocheck;

    public void SetWord(string stword)
    {
        text.text = stword;  
    }

    public void RemoveLetter()
    {
        if (text != null) { 
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
        }
    }

    public void RemoveWord()
    {
       //Debug.Log(index + "is the index we gonna check");
        indextocheck = index;
        foreach (Word otherword in wordmanager.words) 
        {
            //Debug.Log("check for " + indextocheck + "against" + otherword.display.index);
            if (indextocheck < otherword.display.index)
            {
                otherword.display.index--;
                //Debug.Log("indexchanged to" + otherword.display.index);
            }
            else
            {
                //Debug.Log("indexnotchanged because index" + otherword.display.index + "is under" + indextocheck);
            }           
        }
        wordmanager.words.RemoveAt(indextocheck);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        transform.Translate(0f, -fallSpeed  * Time.deltaTime, 0f);

        //Debug.Log(word.word + " " + word.typeIndex + " " + word.word.Length);

    }
}
