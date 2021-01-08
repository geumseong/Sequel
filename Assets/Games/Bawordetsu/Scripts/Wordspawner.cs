using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordspawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
public Worddisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), 5f);
        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        Worddisplay worddisplay = wordObj.GetComponent<Worddisplay>();
        return worddisplay;
    }
}
