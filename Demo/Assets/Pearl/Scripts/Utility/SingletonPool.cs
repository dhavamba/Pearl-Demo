using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace it.amalfi.Pearl
{
    public static class SingletonPool
    {
        #region Protected Fields
        private static Dictionary<Type, MonoBehaviour> singletons;
        private static readonly object _lock = new object();
        #endregion

        static SingletonPool()
        {
            singletons = new Dictionary<Type, MonoBehaviour>();
        }

        public static T Get<T>() where T : MonoBehaviour
        {
            T instance;
            if (!singletons.ContainsKey(typeof(T)))
                FindAndAdd<T>();
            else
            {
                instance = (T)singletons[typeof(T)];
                if (instance == null)
                    FindAndAdd<T>();
            }
            return (T)singletons[typeof(T)];
        }

        private static void Add<T>(T instance) where T : MonoBehaviour
        {
            singletons.Update(typeof(T), instance);
        }

        private static void FindAndAdd<T>() where T : MonoBehaviour
        {
            T instance = FindInstance<T>();
            Add<T>(instance);
        }

        private static T FindInstance<T>() where T : MonoBehaviour
        {
            lock (_lock)
            {
                //Il mono del singletono dev'essere active
                T[] types = (T[])GameObject.FindObjectsOfType(typeof(T));
                if (types.Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong " +
                        " - there should never be more than 1 singleton!");
                    return null;
                }
                else if (types.Length < 1)
                    return null;
                else
                    return types[0];
            }
        }
    }
}
