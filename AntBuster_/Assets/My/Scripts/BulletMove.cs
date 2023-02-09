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
    }

    void Update()
    {
        Invoke("Reload",0.2f);
    }
    
    void Reload()
    {
        gameObject.SetActive(false);        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {       
        if(other.tag == "Ant")
        {
            gameObject.SetActive(false);
        }
    }    
}
