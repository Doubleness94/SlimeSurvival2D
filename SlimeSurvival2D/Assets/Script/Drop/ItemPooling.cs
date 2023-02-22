using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPooling : MonoBehaviour
{
    public static ItemPooling instance;
    public GameObject[] itemPrefebs;

    List<GameObject>[] pools;

    void Awake()
    {
        instance = this;
        pools = new List<GameObject>[itemPrefebs.Length];        
        Init();
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

        foreach(GameObject item in pools[i])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(itemPrefebs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}
