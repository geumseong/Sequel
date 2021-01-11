using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryButton : MonoBehaviour
{
    public int buttonValue;
    Memory memory;
    void Start()
    {
        memory = Memory.instance;
    }
    public void ButtonPress()
    {
        memory.Compute(buttonValue);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        memory.Next();
    }
}
