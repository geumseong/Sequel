using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public bool rotating;
    public bool moving;
    public float speed;
    public float maxs;
    public Rigidbody rb;
    void Update()
    {
        if (rb.velocity.magnitude != maxs)
        { rb.velocity = rb.velocity.normalized * maxs; }
        if (moving)
        {
            rb.AddForce(speed, 0, 0);
        }
        if (rotating)
        { transform.Rotate(0, 0, speed); }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != ("Player"))
        { speed = -speed; }
    }
}
