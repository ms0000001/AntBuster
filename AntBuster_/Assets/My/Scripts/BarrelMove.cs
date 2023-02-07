using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        target = FindObjectOfType<AntMove>().transform;
    }

    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Ant")
        {
            Vector3 dir = target.position - transform.position;
                float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(
                    angle-90, Vector3.forward);
                Debug.Log("조준중");

        }
    }
}
