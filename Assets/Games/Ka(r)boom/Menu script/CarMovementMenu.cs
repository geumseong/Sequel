using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovementMenu : MonoBehaviour
{
    public int speed;
    public bool xAxis;
    public int direction;
    public string face;
    public Sprite car1;
    public Sprite car2;
    Vector3 traffic1;
    Vector3 traffic2;
    Vector3 traffic3;
    Vector3 traffic4;
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

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "car") {
            
        }
        /*else if(collision.tag == "traffic1") {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count1 % 4){
                case 0: //Right
                    face = "right";
                    break;
                case 1: //Left
                    face = "left";
                    break;
                case 2: //Up
                    face = "up";
                    break;
                case 4: //Down
                    face = "down";
                    break;
            }
        }
        else if(collision.tag == "traffic2") {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count2 % 4){
                case 0: //Right
                    face = "right";
                    break;
                case 1: //Left
                    face = "left";
                    break;
                case 2: //Up
                    face = "up";
                    break;
                case 4: //Down
                    face = "down";
                    break;
            }
        }
        else if(collision.tag == "traffic3") {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count3 % 4){
                case 0: //Left
                    face = "left";
                    break;
                case 1: //Up
                    face = "up";
                    break;
                case 2: //Down
                    face = "down";
                    break;
                case 4: //Right
                    face = "right";
                    break;
            }
        }
        else if(collision.tag == "traffic4") {
            switch(GameObject.Find("TrafficController").GetComponent<TrafficLight>().count4 % 4){
                case 0: //Left
                    face = "left";
                    break;
                case 1: //Up
                    face = "up";
                    break;
                case 2: //Down
                    face = "down";
                    break;
                case 4: //Right
                    face = "right";
                    break;
            }
        }*/
        else if(collision.tag == "end"){
            Destroy(this);
        }
    }
}
