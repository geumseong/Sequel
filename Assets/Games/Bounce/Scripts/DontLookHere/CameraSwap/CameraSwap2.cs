using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap2 : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            cam2.SetActive(false);
            cam1.SetActive(true);
        }
    }
}
