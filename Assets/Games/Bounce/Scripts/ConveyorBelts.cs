using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelts : MonoBehaviour
{
    public List<Sprite> animationSprites;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SwitchSprites());
    }

    IEnumerator SwitchSprites() {
        while(true) {
            gameObject.GetComponent<SpriteRenderer>().sprite = animationSprites[0];
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = animationSprites[1];
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = animationSprites[2];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
