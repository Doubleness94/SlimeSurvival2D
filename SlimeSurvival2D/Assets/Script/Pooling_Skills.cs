using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling_Skills : MonoBehaviour
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

    public GameObject GetBullet(int i)
    {
        GameObject select = null;

        foreach (GameObject bullet in pools[i])
        {
            if (!bullet.activeSelf)
            {
                select = bullet;
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
