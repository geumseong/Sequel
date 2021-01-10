using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Death Block").GetComponent<Lava>().isMoving = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Player") {
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win(); ;
        }
    }
}
