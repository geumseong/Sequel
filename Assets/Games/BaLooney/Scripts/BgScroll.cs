using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    float scrollSpeed = 0.75f;
    //float spawnOffset = 10.28f;
    float respawnAxis = 17.31f;
    float removeAxis = -13.49f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);
        if(currentPos.x < removeAxis) {
            transform.position = new Vector3(respawnAxis, transform.position.y, transform.position.z);
        }
    }
}
