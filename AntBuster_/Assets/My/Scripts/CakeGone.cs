using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeGone : MonoBehaviour
{
    public static int i = 0;
    public Sprite fullP;
    public Sprite sevenP;
    public Sprite sixP;
    public Sprite fiveP;
    public Sprite fourP;
    public Sprite threeP;
    public Sprite twoP;
    public Sprite oneP;
    public Sprite zeroP;
    Image image;
    
    void Start()
    {        
        image = GetComponent<Image>();
    }

    void Update()
    {
        //Debug.Log(i);
        HowManyCake();
    }    
    void HowManyCake()
    {
        //케이크 현재 상태
        switch(i)
        {
            case 0:
            image.sprite = fullP;
            break;
            case 1:
            image.sprite = sevenP;
            break;
            case 2:
            image.sprite = sixP;
            break;
            case 3:
            image.sprite = fiveP;
            break;
            case 4:
            image.sprite = fourP;
            break;
            case 5:
            image.sprite = threeP;
            break;
            case 6:
            image.sprite = twoP;
            break;
            case 7:
            image.sprite = oneP;
            break;
            case 8:
            image.sprite = zeroP;
            break;
        }                
            
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //약탈당한 케이크 개수
        if(other.tag == "Ant")
        {
            if(i<9)
            {
                i++;
            }            
        }             
    }
}
