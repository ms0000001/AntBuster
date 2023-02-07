using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBulletPool : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private GameObject[] bullets;

    public int count = 100;
    void Start()
    {
        bullets = new GameObject[count];
        for(int i =0; i<count; i++)
        {
            //풀링 후 shoot이 부모가 되게한다
            GameObject newBullet = Instantiate(bulletPrefab,
            shootingPoint.position,Quaternion.identity);
            newBullet.transform.parent = transform.parent;
            bullets[i] = newBullet;
            bullets[i].SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
