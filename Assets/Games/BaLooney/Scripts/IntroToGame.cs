using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToNextScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GoToNextScene() {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("Game");
    }
}
