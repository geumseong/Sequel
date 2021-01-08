using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public GameObject Win;
    // Start is called before the first frame update
    void Start()
    {
        Win.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(POG());
            GameObject.Find("Death Block").GetComponent<Lava>().isMoving = false;
        }
    }
    IEnumerator POG()
    {
        Win.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
