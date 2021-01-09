using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;

    public float launchForce;
    public float moveSpeed = 5f;
    
    public bool isGrounded = false;
    public bool onIce = false;

    Vector3 movement;
    Vector3 conveyorSpeed;
    Vector3 lastMovement;
    
    void Update()
    {
        Jump();
        if(onIce == false) {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            if(movement.x > 0.4f || movement.x < -0.4f) {
                lastMovement = movement;
            }
        }
        Vector3 finalMovement = movement + conveyorSpeed;
        transform.position += finalMovement * Time.deltaTime * moveSpeed;
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true && onIce == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }

    public void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "IcePlatform") {
            onIce = true;
            movement = lastMovement;
        }

        else if(collider.tag == "ConveyorBeltLeft") {
            conveyorSpeed = new Vector3(0.9f, 0, 0);
        }

        else if(collider.tag == "ConveyorBeltRight") {
            conveyorSpeed = new Vector3(0.9f, 0, 0);
        }
    }
    public void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "IcePlatform") {
            onIce = false;
        }

        else {
            conveyorSpeed = new Vector3(0, 0, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death")
        {
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose();
        }
    }
}
