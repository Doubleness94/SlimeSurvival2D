using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling_Monsters : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        Init();
    }

    void Init()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject GetMonster(int i)
    {
        GameObject select = null;

        foreach (GameObject monster in pools[i])
        {
            if (!monster.activeSelf)
            {
                select = monster;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}
