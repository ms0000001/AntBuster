using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AntMove : MonoBehaviour
{
    public RectTransform cake;
    private RectTransform antObj = default;
    public RectTransform home;
    public GameObject haveCake;
    public int speed;
    public bool isDead = false;
    bool start = true;
    bool end = false;
    bool cakeOn = false;

    float antMAXHP = 100;
    float currentHP = 100;
    float afterHP;

    void Start()
    {
        antObj = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        Die();
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
                string enemy = "Cake";
                GameObject caketarget = GameObject.FindGameObjectWithTag(enemy);
                //머리회전
                Vector3 dir = caketarget.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(
                    angle-90, Vector3.forward);

                //케이크로 이동
                antObj.anchoredPosition = Vector3.MoveTowards(
                    antObj.anchoredPosition, cake.anchoredPosition,
                     Time.deltaTime*speed*100);
                Debug.Log("출발");
            }
            if(end == true)
            {
                // 머리회전
                string enemy = "Home";
                GameObject hometarget = GameObject.FindGameObjectWithTag(enemy);
                Vector3 dir = hometarget.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(
                    angle-90, Vector3.forward);

                // 집으로 이동
                antObj.anchoredPosition = Vector3.MoveTowards(
                    antObj.anchoredPosition, home.anchoredPosition,
                     Time.deltaTime*speed*100);
                Debug.Log("귀환");
            }

            // 케이크를 업고가는 개미
            if(CakeGone.i !=9)
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
        // hp가 0일 경우
        if(currentHP <= 0)
        {
            isDead = true;
        }
        if(isDead == true)
        {
            // 케이크 들고 사망 시 케이크 개수 복구
            if(cakeOn == true)
            {
                haveCake.SetActive(false);
                CakeGone.i--;
                Debug.Log("케이크 돌려받았다");
            }
            // 일반 사망
            gameObject.SetActive(false);
            Debug.Log("사망");
        }
    }
    void CakeHeal()
    {
        // 케이크ON 시 체력회복
        currentHP += currentHP *0.5f;
        if(currentHP>antMAXHP)
        {
            currentHP = antMAXHP;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 케이크와 접촉 시
        if(other.tag == "Cake")
        {
            start = false;
            end = true;
            cakeOn = true;
            CakeHeal();
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

        //총알과 접촉 시
        if(other.tag == "Bullet")
        {
            Debug.Log("맞았다");
            currentHP -=10;
        }
    }
}
