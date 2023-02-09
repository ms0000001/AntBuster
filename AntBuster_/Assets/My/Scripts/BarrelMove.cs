using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    private GameObject target;
    void Start()
    {
    }

    void Update()
    {
    }

    void TargetFind()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        //target = FindObjectOfType<AntMove>().transform;
        string enemy = "Ant";
        target = GameObject.FindGameObjectWithTag(enemy);
        if(other.tag == "Ant")
        {
            Vector3 dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(
                    angle-90, Vector3.forward);
                Debug.Log("조준중");            
        }        
    }
}
