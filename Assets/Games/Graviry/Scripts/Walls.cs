using UnityEngine;

public class Walls : MonoBehaviour
{
    public bool wall;
    public bool drag;
    public Rigidbody rb;
    public int wait;

    void Start()
    {
        wall = false;
        drag = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == this.gameObject.name)
            {
                if (wall == true)
                {

                    if (drag == false)
                    {
                        rb.drag = 15;
                        drag = true;
                        Debug.Log("Dragging");
                    }

                }
                else
                {
                    Debug.Log(hit.transform.gameObject.name);
                    MouseMovement.movement = true;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.drag = 10;
            rb.useGravity = true;
            wall = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wall = false;
            drag = false;
            rb.drag = 0;
        }
    }
}
