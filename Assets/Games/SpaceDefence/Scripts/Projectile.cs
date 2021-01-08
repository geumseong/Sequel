using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public ParticleSystem ps;
    public Vector2 direction;
    public float damage;
    GameObject gameStateManagerObj;
    public GameObject DeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameStateManagerObj = GameObject.Find("GameStateManager");
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "Enemy") {
            if(collider.gameObject.transform.parent.gameObject.tag == "Meteorite"){
                int hp = collider.gameObject.transform.parent.gameObject.GetComponent<Meteorite>().healthPoint;
                collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            else if(collider.gameObject.transform.parent.gameObject.tag == "SmallAlien") {
                int hp = collider.gameObject.transform.parent.gameObject.GetComponent<SmallAlien>().healthPoint;
                collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            else if(collider.gameObject.transform.parent.gameObject.tag == "MediumAlien") {
                int hp = collider.gameObject.transform.parent.gameObject.GetComponent<MediumAlien>().healthPoint;
                collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            else if(collider.gameObject.transform.parent.gameObject.tag == "BossAlien") {
                int hp = collider.gameObject.transform.parent.gameObject.GetComponent<BossAlien>().healthPoint;
                collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            if(collider.transform.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount <= 0) {
                if(collider.gameObject.transform.parent.gameObject.tag == "Meteorite"){
                    gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(20);
                }
                else if(collider.gameObject.transform.parent.gameObject.tag == "SmallAlien") {
                    gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(50);
                }
                else if(collider.gameObject.transform.parent.gameObject.tag == "MediumAlien") {
                    gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(100);
                }
                else if(collider.gameObject.transform.parent.gameObject.tag == "BossAlien") {
                    gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(1000);
                }
                Destroy(collider.gameObject.transform.parent.gameObject);
                GameObject effectIns = (GameObject)Instantiate(DeathEffect, collider.gameObject.transform.position, transform.rotation);
                Destroy(effectIns, 1f);
                if (gameStateManagerObj.GetComponent<GameStateManager>().waveStatus == false
                    && gameStateManagerObj.GetComponent<GameStateManager>().countDownStatus == false) {
                    gameStateManagerObj.GetComponent<GameStateManager>().StartCountDown();
                }
            }
            Destroy(gameObject);
        }
        else if(collider.tag == "ProjectileRemover") {
            Destroy(gameObject);
        }
    }
}
