using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AntMove : MonoBehaviour
{
    public RectTransform cake;
    public RectTransform home;
    public GameObject haveCake;
    public int speed;
    public bool isDead = false;
    public static bool start = true;
    public static bool end = false;
    public static bool cakeOn = false;

    void Start()
    {
    }

    void Update()
    {
    }
    void FixedUpdate() 
    {        
        Move();
    }

    void Move()
    {
        if(isDead == false)
        {
            if(start == true)
            {
                //머리회전
                Vector3 dir = cake.position - transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(
                    angle-90, Vector3.forward);

                //케이크로 이동
                gameObject.transform.position = Vector3.MoveTowards(
                    transform.position, cake.position, Time.deltaTime*speed);
                Debug.Log("출발");
            }
            if(end == true)
            {
                //머리회전
                Vector3 dir = home.position - transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(
                    angle-90, Vector3.forward);

                //집으로 이동
                gameObject.transform.position = Vector3.MoveTowards(
                    transform.position, home.position, Time.deltaTime*speed);
                Debug.Log("귀환");
            }
            if(CakeGone.i<9)
            {
                if(cakeOn == true)
                {
                    haveCake.SetActive(true);
                }
                if(cakeOn == false)
                {
                    haveCake.SetActive(false);
                }
            }
            
        }
    }
    void Die()
    {
        if(isDead == true)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //케이크와 접촉 시
        if(other.tag == "Cake")
        {
            start = false;
            end = true;
            cakeOn = true;
            Debug.Log("도착, 케이크 들었다");
        }
        //집과 접촉 시
        if(other.tag == "Home")
        {
            start = true;
            end = false;
            cakeOn = false;
            Debug.Log("반복, 케이크 놨다");
        }
    }
}
