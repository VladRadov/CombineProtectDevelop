using System.Collections.Generic;
using UnityEngine;

public class PoolObjects<T> where T : MonoBehaviour
{
    protected static List<T> _objects = new List<T>();

    public static T GetObject(T prefabObject)
    {
        foreach (var currentObject in _objects)
        {
            if (currentObject.gameObject.activeSelf == false && currentObject.name.Contains(prefabObject.name))
            {
                currentObject.gameObject.SetActive(true);
                return currentObject;
            }
        }

        return AddObject(prefabObject);
    }

    public static T GetObject(T prefabObject, Transform parent)
    {
        foreach (var currentObject in _objects)
        {
            if (currentObject.gameObject.activeSelf == false && currentObject.name.Contains(prefabObject.name))
            {
                currentObject.gameObject.SetActive(true);
                return currentObject;
            }
        }

        return AddObject(prefabObject, parent);
    }

    protected static T AddObject(T prefabObject)
    {
        var createdObject = UnityEngine.Object.Instantiate(prefabObject);
        _objects.Add(createdObject);
        return createdObject;
    }

    protected static T AddObject(T prefabObject, Transform parent)
    {
        var createdObject = UnityEngine.Object.Instantiate(prefabObject, parent);
        _objects.Add(createdObject);
        return createdObject;
    }

    public static void DisactiveObjects()
    {
        foreach (var currentObject in _objects)
        {
            if (currentObject.gameObject.activeSelf)
                currentObject.gameObject.SetActive(false);
        }
    }

    public static T Find(System.Predicate<T> predicat) => _objects.Find(predicat);

    public static List<T> FindAll(System.Predicate<T> predicat) => _objects.FindAll(predicat);
}
