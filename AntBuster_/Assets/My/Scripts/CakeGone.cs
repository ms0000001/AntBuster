using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGone : MonoBehaviour
{
    int i = 0;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Ant"){
            i++;
            animator.SetInteger("Stolen", i);
            
        }
    }    
}
