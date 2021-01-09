using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseMovement : MonoBehaviour
{
    public GameObject respawn;
    public Transform respawnpos;
    public float maxspeed;
    public static bool drag;
    public Rigidbody rb;
    Vector3 newPosition;
    Vector3 diff;
    public static MouseMovement Action;
    public static bool movement;

    void Start()
    {
        Time.timeScale = 1;
        movement = false;
    }

    void Update()
    {
        if (movement == true)
        { Movement(); }
        if (rb.velocity.magnitude > maxspeed)
        { rb.velocity = rb.velocity.normalized * maxspeed; }
        if (Input.GetKeyDown(KeyCode.Escape))
        { GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose(); }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //this.gameObject.transform.position = respawn.transform.position;
            Debug.Log("obstacle touched");
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Loose();
        }
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("goalreached");
            //Sceneloader.goalreached = true;
            GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();
        }
    }
    public void Movement()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            rb.velocity = rb.velocity.normalized * 0;
            rb.useGravity = false;
            rb.drag = 0;
            newPosition = hit.point;
            diff = newPosition - transform.position;
            rb.AddForce(diff, ForceMode.Impulse);
            movement = false;
        }
    }
}
