using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject button;
    float x;
    float y;
    float z;
    Vector3 pos;
    //Vector3 pos;

    public Transform playerBody;

    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 200f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Player")
         {
             // this wont move the object forwards but will reset it's position to 0, 0, 1
             x = Random.Range(-7, 7);
             y = Random.Range(-1, 3.5f);
             z = 0;
             pos = new Vector3(x, y, z);
             button.transform.position = new Vector3(x, y, z);
             // this code will do the trick
             button.transform.position += button.transform.forward * Time.deltaTime * 5f; // can be any float number
             GameObject.Find("ScoreUI").GetComponent<ScoreContoller>().ScoreUp();
         }
     }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // this wont move the object forwards but will reset it's position to 0, 0, 1
            x = Random.Range(-7, 7);
            y = Random.Range(-1, 3.5f);
            z = 0;
            pos = new Vector3(x, y, z);
            button.transform.position = new Vector3(x, y, z);
            // this code will do the trick
            button.transform.position += button.transform.forward * Time.deltaTime * 5f; // can be any float number
            GameObject.Find("ScoreUI").GetComponent<ScoreContoller>().ScoreUp();
        }
    }
}
