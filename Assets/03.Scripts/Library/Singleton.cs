using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class Singleton<T> where T: MonoBehaviour
{   
    private static T inst = null;
    public static T Inst
    { 
        get
        {
            return inst;
        }
        set
        {
            if ((inst != null) && (inst != value))
            {
                Debug.LogAssertion($"{value.name} is trying to instanciate, but {typeof(T)} is singleton class and already exists.");
                Object.Destroy(value.gameObject);
            }
            else
            {
                Object.DontDestroyOnLoad(value);
                inst = value;
            }
        }
    }
}