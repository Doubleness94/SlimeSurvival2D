using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject[] objectPrefebs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[objectPrefebs.Length];

    }

    void Init()
    {
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;

        foreach(GameObject _object in pools[i])
        {
            if (!_object.activeSelf)
            {
                select = _object;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(objectPrefebs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
    
}
