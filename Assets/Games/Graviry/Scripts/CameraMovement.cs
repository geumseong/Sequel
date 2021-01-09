using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    Vector3 shift;
    public static CameraMovement cam;
    void Start()
    {
        cam = this;
        shift = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + shift;
    }
    public void PlayerCamera()
    { 
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    public void GameOverCamera()
    { 
        player = this.gameObject.transform; 
    }
}
