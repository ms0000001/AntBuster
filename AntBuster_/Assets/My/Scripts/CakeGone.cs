using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGone : MonoBehaviour
{
    int i = 0;
    Animator animator;
    public static int cakeP = 8;
    
    void Start()
    {        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
    }
}
