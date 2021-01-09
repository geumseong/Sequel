using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rb;
    public ParticleSystem ps;
    public GameObject target;
    Transform projectile;
    Transform gravity;
    public bool gravityPull;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projectile = this.transform;
        gravityPull = false;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "target") {
            Debug.Log("target hit");
            //ParticleSystem e = Instantiate(ps);
            //e.transform.position = new Vector2(transform.position.x, transform.position.y);
            //e.Play();

            Vector2 newTargetPos = new Vector2(collision.gameObject.transform.position.x, Random.Range(-2.5f, 2.5f));
            GameObject newTarget = Instantiate(target);
            newTarget.transform.position = newTargetPos;
            FindObjectOfType<Bow>().score++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "wall") {
            Debug.Log("wall hit");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Gravity") {
            gravity = collider.transform;
            gravityPull = true;
            StartCoroutine(Gravity());
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "Gravity") {
            gravityPull = false;
        }
    }

    IEnumerator Gravity() {
        while(gravityPull) {
            Vector2 projectilePos = new Vector2(projectile.position.x, projectile.position.y);
            Vector2 gravityPos = new Vector2(gravity.position.x, gravity.position.y);
            Vector2 dir = (gravityPos - projectilePos).normalized;
            projectile.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir.x, dir.y) * 20f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
