using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallAlien : MonoBehaviour
{
    public int healthPoint = 100;
    public float speed;
    public Vector3 direction;
    bool moving;
    public float range = 15f;
    
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float damage;
    public float shotSpeed;
    public GameObject projectile;
    public Transform firePoint;
    Rigidbody2D rb;
    Transform target;
    public GameObject rotateImage;


    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Primary weapon").transform;
        Vector3 direction = transform.position - GameObject.Find("earth").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving == true && target != null) {
            transform.Translate(direction * speed * Time.deltaTime);
            Vector2 rotationPivot = transform.position;
            Vector2 targetPos = target.position;
            Vector2 dir = targetPos - rotationPivot;
            rotateImage.transform.up = -dir;
        }
        float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position); 
        if(distanceToEnemy < range) {
            if(fireCountdown <= 0f) {
                PewPew();
                fireCountdown = 1f/fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player") {
            moving = false;
        }
    }

    void PewPew() {
        GameObject newProjectile = Instantiate(projectile, firePoint.position, transform.rotation);
        //newProjectile.transform.position = firePoint.position;
        newProjectile.GetComponent<EnemyProjectile>().damage = damage;
        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * shotSpeed);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
