using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    public int speed;
    public bool xAxis;
    public int direction;
    public string face;
    public Sprite car1;
    public Sprite car2;
    public ParticleSystem effect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(face == "right") {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = car1;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if(face == "left") {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            this.GetComponent<SpriteRenderer>().sprite = car2;
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else if(face == "up") {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            this.GetComponent<SpriteRenderer>().sprite = car1;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            this.GetComponent<SpriteRenderer>().sprite = car1;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if(transform.position.x > -6.1 && transform.position.x < -5.5 && transform.position.y < 2.5 && transform.position.y > 1.9) {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count1 % 4){
                case 0: //Right
                    if(face != "left")
                        face = "right";
                    break;
                case 1: //Left
                    if(face != "right")
                        face = "left";
                    break;
                case 2: //Up
                    if(face != "down")
                    face = "up";
                    break;
                case 3: //Down
                    if(face != "up")
                        face = "down";
                    break;
            }
        }
        if(transform.position.x > -6.1 && transform.position.x < -5.5 && transform.position.y < -2.38 && transform.position.y > -2.98) {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count2 % 4){
                case 0: //Right
                    if(face != "left")
                        face = "right";
                    break;
                case 1: //Left
                    if(face != "right")
                        face = "left";
                    break;
                case 2: //Up
                    if(face != "down")
                    face = "up";
                    break;
                case 3: //Down
                    if(face != "up")
                        face = "down";
                    break;
            }
        }
        if(transform.position.x > 5.01 && transform.position.x < 5.61 && transform.position.y < 2.5 && transform.position.y > 1.9) {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count4 % 4){
                case 0: //Left
                    if(face != "right")
                        face = "left";
                    break;
                case 1: //Up
                    if(face != "down")
                        face = "up";
                    break;
                case 2: //Down
                    if(face != "up")
                        face = "down";
                    break;
                case 3: //Right
                    if(face != "left")
                        face = "right";
                    break;
            }
        }
        if(transform.position.x > 5.01 && transform.position.x < 5.61 && transform.position.y < -2.38 && transform.position.y > -2.98) {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count3 % 4){
                case 0: //Left
                    if(face != "right")
                        face = "left";
                    break;
                case 1: //Up
                    if(face != "down")
                        face = "up";
                    break;
                case 2: //Down
                    if(face != "up")
                        face = "down";
                    break;
                case 3: //Right
                    if(face != "left")
                        face = "right";
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "car") {
            ParticleSystem e = Instantiate(effect);
            e.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
            e.Play();
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().carDestroyedCount();
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().IncreaseScore();
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().CarCountDown();
            Destroy(gameObject);
        }
        else if(collision.tag == "mapEnd"){
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().DecreaseLives();
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().CarCountDown();
            Destroy(gameObject);
        }
    }
}
