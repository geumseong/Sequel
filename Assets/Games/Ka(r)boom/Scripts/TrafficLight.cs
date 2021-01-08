using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLight : MonoBehaviour
{
    public Sprite[] s1;
    public Sprite[] s2;
    public Sprite[] s3;
    public Sprite[] s4;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;

    public int count1 = 0;
    public int count2 = 0;
    public int count3 = 0;
    public int count4 = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite1(){
        count1++;
        b1.image.sprite = s1[count1 % s1.Length];
    }
    public void ChangeSprite2(){
        count2++;
        b2.image.sprite = s2[count2 % s2.Length];
    }
    public void ChangeSprite3(){
        count3++;
        b3.image.sprite = s3[count3 % s3.Length];
    }
    public void ChangeSprite4(){
        count4++;
        b4.image.sprite = s4[count4 % s4.Length];
    }
}
