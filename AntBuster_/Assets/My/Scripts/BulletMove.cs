using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Rigidbody2D bullet;
    float speed = 8f;
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>(); 
        bullet.velocity = transform.up*speed;     
        Debug.Log("가는중");        
    }

    void Update()
    {        
    }
}
