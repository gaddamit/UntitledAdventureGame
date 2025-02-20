using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    SetupInstance();
                }
            }
            
            return _instance;
        }
    }
    
    protected virtual void Init() {}

    protected void Awake()
    {
        Init();
        RemoveDuplicates();
    }

    static void SetupInstance()
    {
        _instance = FindFirstObjectByType<T>();

        if (_instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).Name;
            _instance = obj.AddComponent<T>();
            DontDestroyOnLoad(obj);
        }
    }

    void RemoveDuplicates()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
