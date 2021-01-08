using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthChange : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject earth;
    public List<Sprite> earthSpriteList;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateSprite", 0f, 0.1f);
    }

    // Update is called once per frame
    void UpdateSprite()
    {
        if(healthBar.GetComponent<Image>().fillAmount >= 0.67f) {
            earth.GetComponent<SpriteRenderer>().sprite = earthSpriteList[0];
        }
        else if(healthBar.GetComponent<Image>().fillAmount < 0.67f && healthBar.GetComponent<Image>().fillAmount >= 0.33f) {
            earth.GetComponent<SpriteRenderer>().sprite = earthSpriteList[1];
        }
        else if(healthBar.GetComponent<Image>().fillAmount < 0.33f) {
            earth.GetComponent<SpriteRenderer>().sprite = earthSpriteList[2];
        }
    }
}
