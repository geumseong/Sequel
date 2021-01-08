using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceProjectile : MonoBehaviour
{
    float targetMoveSpeed;
    string enemyType;

    Rigidbody2D rb;
    public ParticleSystem ps;
    public float damage;
    public float speed;
    Transform target;
    GameObject gameStateManagerObj;
    public GameObject DeathEffect;
    Meteorite meteoriteComponent;
    SmallAlien smallAlienComponent;
    MediumAlien mediumAlienComponent;
    BossAlien bossAlienComponent;

    public void Seek (Transform _target) {
        target = _target;
        switch(_target.gameObject.transform.parent.gameObject.tag) {
            case "Meteorite": {
                meteoriteComponent = _target.gameObject.transform.parent.gameObject.GetComponent<Meteorite>();
                targetMoveSpeed = meteoriteComponent.speed;
                enemyType = "Meteorite";
                break;
            }
            case "SmallAlien": {
                smallAlienComponent = _target.gameObject.transform.parent.gameObject.GetComponent<SmallAlien>();
                targetMoveSpeed = smallAlienComponent.speed;
                enemyType = "SmallAlien";
                break;
            }
            case "MediumAlien": {
                mediumAlienComponent = _target.gameObject.transform.parent.gameObject.GetComponent<MediumAlien>();
                targetMoveSpeed = mediumAlienComponent.speed;
                enemyType = "MediumAlien";
                break;
            }
            case "BossAlien": {
                bossAlienComponent = _target.gameObject.transform.parent.gameObject.GetComponent<BossAlien>();
                targetMoveSpeed = bossAlienComponent.speed;
                enemyType = "BossAlien";
                break;
            }
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameStateManagerObj = GameObject.Find("GameStateManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        float angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget() {
        switch(enemyType) {
            case "Meteorite": {
                meteoriteComponent.speed = targetMoveSpeed/2;
                break;
            }
            case "SmallAlien": {
                smallAlienComponent.speed = targetMoveSpeed/2;
                break;
            }
            case "MediumAlien": {
                mediumAlienComponent.speed = targetMoveSpeed/2;
                break;
            }
            case "BossAlien": {
                bossAlienComponent.speed = targetMoveSpeed/2;
                break;
            }
        }
        if(target.gameObject.transform.parent.gameObject.tag == "Meteorite"){
                int hp = target.gameObject.transform.parent.gameObject.GetComponent<Meteorite>().healthPoint;
                target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "SmallAlien") {
                int hp = target.gameObject.transform.parent.gameObject.GetComponent<SmallAlien>().healthPoint;
                target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "MediumAlien") {
                int hp = target.gameObject.transform.parent.gameObject.GetComponent<MediumAlien>().healthPoint;
                target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "BossAlien") {
                int hp = target.gameObject.transform.parent.gameObject.GetComponent<BossAlien>().healthPoint;
                target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount -= (damage/hp);
            }
        if(target.GetChild(0).transform.Find("HPBarFull").GetComponent<Image>().fillAmount <= 0) {
            if(target.gameObject.transform.parent.gameObject.tag == "Meteorite"){
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(20);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "SmallAlien") {
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(50);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "MediumAlien") {
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(100);
            }
            else if(target.gameObject.transform.parent.gameObject.tag == "BossAlien") {
                gameStateManagerObj.GetComponent<GameStateManager>().IncreaseMoney(1000);
            }
            Destroy(target.gameObject.transform.parent.gameObject);
            GameObject effectIns = (GameObject)Instantiate(DeathEffect, target.position, transform.rotation);
            Destroy(effectIns, 1f);
            if(gameStateManagerObj.GetComponent<GameStateManager>().waveStatus == false
                && gameStateManagerObj.GetComponent<GameStateManager>().countDownStatus == false) {
                gameStateManagerObj.GetComponent<GameStateManager>().StartCountDown();
            }
        }
        Destroy(gameObject);
    }
    void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "ProjectileRemover") {
            Destroy(gameObject);
        }
    }
}
