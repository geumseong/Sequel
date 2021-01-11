using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition((Vector2)transform.position + (Vector2.left * Time.deltaTime * speed));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose();
        }
    }
}
