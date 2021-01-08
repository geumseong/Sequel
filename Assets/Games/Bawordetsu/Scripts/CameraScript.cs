using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject x2;
    public GameObject x3;
    public GameObject x4;
    public GameObject x5;
    public IEnumerator Shake (float duration, float magnitude, float multiplier)
    {
        switch (multiplier)
        {
            case 2:
                x2.SetActive(true);
                break;
            case 3:
                x3.SetActive(true);
                break;
            case 4:
                x4.SetActive(true);
                break;
            case 5:
                x5.SetActive(true);
                break;
            default:
                break;
        }
        Vector3 originalPos =transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
        x2.SetActive(false);
        x3.SetActive(false);
        x4.SetActive(false);
        x5.SetActive(false);
    }
}
