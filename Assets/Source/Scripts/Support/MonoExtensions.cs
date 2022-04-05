using UnityEngine;

namespace Ingame.Extensions
{
    public  static class MonoExtensions
    {
        public static T CheckAndGetComponent<T>(this MonoBehaviour m) where T : Component
        {
            if (!m.TryGetComponent(out T component))
            {
                m.gameObject.AddComponent<T>();
                component =  m.GetComponent<T>();
            }

            return component;
        }
    }
}