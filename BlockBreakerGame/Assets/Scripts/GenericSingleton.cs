using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {

        private static T instance;

        /// <summary>
        /// 
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
