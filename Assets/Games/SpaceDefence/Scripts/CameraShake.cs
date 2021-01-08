using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void StartShake() {
        StartCoroutine(Shake(0.15f, 0.25f));
    }
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(0.3f, 2.4f) * magnitude;

            transform.position = new Vector3(x, y, -10);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(0, 1, -10);
        yield return null;
    }
}