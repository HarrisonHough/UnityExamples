using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Generic Singleton Class 
*/

public class GenericSingleton<T> : MonoBehaviour where T : Component
{

    private static T instance;
    [SerializeField]
    public bool destroyOnLoad;
    
    public static T Instance
    {
        get
        {
            //check if an instance already exists
            if (instance == null)
            {
                Debug.Log("No instance of GameManager found");
                //if not create new instance
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            //if instance exists return instance
            return instance;
        }
    }

    /// <summary>
    /// Called on awake, before the start function
    /// </summary>
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (!destroyOnLoad)
            {
                Debug.Log(gameObject.name + "Will NOT destroy on load");
                DontDestroyOnLoad(gameObject);
            }
            else
                Debug.Log(gameObject.name + "Will destroy on load");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
