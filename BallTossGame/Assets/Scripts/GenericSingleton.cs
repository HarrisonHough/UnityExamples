using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: Generic Singleton Class 
*/

public class GenericSingleton<T> : MonoBehaviour where T : Component
{

    private static T instance;
    [SerializeField]
    private bool destroyOnLoad;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                FindOrCreateInstance();
            }
            return instance;
        }
    }

    private static void FindOrCreateInstance()
    {
        instance = FindObjectOfType<T>();
        if (instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).Name;
            instance = obj.AddComponent<T>();
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            SetInstance();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void SetInstance()
    {
        instance = this as T;
        if (!destroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
