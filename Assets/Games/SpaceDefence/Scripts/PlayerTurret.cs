using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    Vector2 direction;
    public float shotSpeed;
    public GameObject projectile;
    public float damage;
    public Transform firePoint;
    bool fireStatus = false;
    private float fireCountdown = 0f;
    public float fireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rotationPivot = transform.position; //position of your turret
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of moouse
        direction = mousePosition - rotationPivot; //Finds Vector2 direction by (mousePos - turretPos)
        transform.up = direction; //And transform.up - direction somehow does the rest.
        if(Input.GetMouseButtonDown(0)) {
            fireStatus = true;
        }
        if(Input.GetMouseButtonUp(0)) {
            fireStatus = false;
        }
        if(fireStatus == true) {
            if(fireCountdown <= 0f) {
                Shoot();
                fireCountdown = 1f/fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    public void Shoot(){
        GameObject newProjectile = Instantiate(projectile, firePoint.position, transform.rotation);
        //newProjectile.transform.position = firePoint.position;
        newProjectile.GetComponent<Projectile>().damage = damage;
        newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * shotSpeed);
    }
}
