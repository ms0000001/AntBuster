using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSingleton<T> : GComponent where T : GSingleton<T>
{
    private static T _instance = default;

    public static T Instance 
    {
        get
        {
            if(GSingleton<T>._instance == default || _instance == default)
            {
                GSingleton<T>._instance = 
                    GFunc.CreateObj<T>(typeof(T).ToString());
                DontDestroyOnLoad(_instance.gameObject);
            }   //인스턴스가 비어 있을 때 새로 인스턴스화 한다.
            return _instance;
        }
    }
    public override void Awake()
    {
        base.Awake();
    }

    public void Create()
    {
        this.Init();
    }       //Create()

    protected virtual void Init(){

    }
}