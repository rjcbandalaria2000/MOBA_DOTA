using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class SingletonManager
{
    private static List<MonoBehaviour> singletons = new List<MonoBehaviour>();

    public static T Get<T>() where T : MonoBehaviour
    {
        return singletons
            .Where(s => s is T)
            .FirstOrDefault() as T;
    }

    public static void Register<T>(T obj) where T : MonoBehaviour
    {
        singletons.Add(obj);
    }

    public static void Remove<T>() where T : MonoBehaviour
    {
        T singleton = Get<T>();
        singletons.Remove(singleton);
    }
   
}
