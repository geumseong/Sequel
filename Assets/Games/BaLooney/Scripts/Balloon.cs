using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Rigidbody2D rb;
    float riseForce = 12.5f;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            if(gameManager.paused == false) {
                Rise();
            }
        }
    }

    /*
    void FixedUpdate() {
        if(Input.GetKey("space")) {
            Rise();
        }
    }
    */

    void Rise() {
        rb.AddForce(Vector2.up * riseForce);
    }
}
