using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float damage;
    public float shotSpeed;
    public GameObject projectile;
    public Transform firePoint;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.05f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); 
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        }
        else {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            return;
        }

        /*
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        target.rotation = Quaternion.Euler (0f, 0f, rotation.z);
        */
        
        Vector2 rotationPivot = transform.position;
        Vector2 targetPos = target.position;
        dir = targetPos - rotationPivot;
        transform.up = dir;
        
        if(fireCountdown <= 0f) {
            PewPew();
            fireCountdown = 1f/fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void PewPew() {
        GameObject newProjectile = Instantiate(projectile, firePoint.position, transform.rotation);
        newProjectile.GetComponent<TurretProjectile>().damage = damage;
        newProjectile.GetComponent<TurretProjectile>().speed = shotSpeed;

        TurretProjectile projectileScript = newProjectile.GetComponent<TurretProjectile>();

        if(projectileScript != null) {
            projectileScript.Seek(target);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
