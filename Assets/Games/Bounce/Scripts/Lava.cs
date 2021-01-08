using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true) {
            transform.Translate(new Vector3(0, 1.5f, 0) * Time.deltaTime);
        }
    }
}
