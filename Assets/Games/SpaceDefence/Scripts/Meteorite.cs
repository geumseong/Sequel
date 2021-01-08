using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteorite : MonoBehaviour
{
    GameObject cameraShake;
    //public GameObject player;
    public GameObject rotateImageObj;
    public float speed;
    public Vector3 direction;
    public int healthPoint = 70;
    public int rotationSpeed;
    GameObject gameStateManagerObj;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.Find("Main Camera");
        gameStateManagerObj = GameObject.Find("GameStateManager");
        Vector3 direction = transform.position - GameObject.Find("earth").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        rotateImageObj.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player") {
            cameraShake.GetComponent<CameraShake>().StartShake();
            if(gameStateManagerObj.GetComponent<GameStateManager>().waveStatus == false
                && gameStateManagerObj.GetComponent<GameStateManager>().countDownStatus == false) {
                gameStateManagerObj.GetComponent<GameStateManager>().StartCountDown();
            }
            GameObject healthPoint = GameObject.Find("EarthHPBarFull");
            healthPoint.GetComponent<Image>().fillAmount -= 0.1f;
            Debug.Log("collided");
            if(healthPoint.GetComponent<Image>().fillAmount <= 0) {
                Debug.Log("Game Over");
                gameStateManagerObj.GetComponent<GameStateManager>().GameOver();
            }
           Destroy(gameObject);
        }
    }
}
