using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab;
    private GameObject[] ants;
    private int currentIndex = 0;
    public int antcount = 6;

    float timer;
    float setTime;
    void Start()
    {
        timer = 0f;
        setTime = 1f;
        ants = new GameObject[antcount];
        for(int i=0; i<antcount; i++)
        {
            GameObject newant = Instantiate(antPrefab,
            this.gameObject.transform.position,Quaternion.identity);
            newant.transform.SetParent(transform.parent);
            ants[i]=newant;
            ants[i].SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        AntGetWork();
    }
    
    void AntGetWork()
    {
        if(timer>setTime)
        {
            if(currentIndex < 6)
            {
                ants[currentIndex].transform.position = transform.position;
                ants[currentIndex].SetActive(true);
                currentIndex++;
            }
            timer =0;
        }
        // if(currentIndex == 6)
        // {
        //     currentIndex = 0;
        // }
    }

    void ResetPosition()
    {
        
    }  

        
}
