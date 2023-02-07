using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    public RectTransform cake;
    public RectTransform home;
    public int speed;
    bool start = true;
    bool end = false;

    void Start()
    {
    }

    void Update()
    {
        if(start == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(
                transform.position, cake.position, Time.deltaTime*speed);
            Debug.Log("출발");
        }
        if(end == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(
                transform.position, home.position, Time.deltaTime*speed);
            Debug.Log("귀환");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Cake")
        {
            start = false;
            end = true;
            Debug.Log("도착");
        }
        if(other.tag == "Home")
        {
            start = true;
            end = false;
            Debug.Log("반복");
        }
    }
}
