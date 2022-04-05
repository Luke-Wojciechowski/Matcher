using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Source.Scripts
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {

                    var m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
                    if (m_Instance == null)
                    {
                        var g = new GameObject().AddComponent<T>();
                        m_Instance = g;
                    }

                    _instance = m_Instance;
                }
                return _instance;
            }

        }

        private void Awake()
        {
            if (_instance !=null && _instance!=this)
            {
                Destroy(this);
                return;
            } 
            
            _instance = this as T;
            AwakeAfter();
        }
        
        protected virtual void AwakeAfter()
        {
            
        }
    }
}