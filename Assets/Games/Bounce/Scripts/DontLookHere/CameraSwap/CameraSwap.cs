using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        if(gameObject.name == "CameraSwap (3)") {
            GameObject.Find("Death Block").GetComponent<Lava>().isMoving = true;
        }
    }
}
