using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBulletPool : MonoBehaviour
{
    public RectTransform shootingPoint;
    public GameObject bulletPrefab;
    private GameObject[] bullets;
    private int currentIndex = 0;
    float timer;
    float setTime;



    public int count = 100;
    void Start()
    {
        timer = 0f;
        setTime = 0.5f;
        

        bullets = new GameObject[count];
        for(int i =0; i<count; i++)
        {
            //풀링 후 shoot이 부모가 되게한다
            GameObject newBullet = Instantiate(bulletPrefab,
            shootingPoint.position,Quaternion.identity);
            newBullet.transform.SetParent(transform.parent);
            bullets[i] = newBullet;
            bullets[i].SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void Shootting()
    {
        //0.5초 간격으로 총알 발사
        if(timer > setTime)
        {            
            bullets[currentIndex].transform.position = 
            transform.position;
            bullets[currentIndex].SetActive(true);        
            Debug.Log("발사");        
            
            currentIndex++; 
            timer = 0f;

            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        //사정거리 내 개미 발견 시 사격 시작
        if(other.tag == "Ant")
        {
            Shootting();
        }          
    }    
}
