using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPooling : MonoBehaviour
{
    public static CrystalPooling instance;

    [SerializeField]
    GameObject greenCrystalPrefab;
    public Queue<GameObject> newQue = new Queue<GameObject>();
    [SerializeField]
    Transform poolParent;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < 500; i++)
        {
            GameObject crystal = Instantiate(instance.greenCrystalPrefab);
            newQue.Enqueue(crystal);            
            crystal.SetActive(false);
            crystal.transform.SetParent(poolParent);
        }
    }

    public void ReturnCrystal(GameObject r_object)
    {
        newQue.Enqueue(r_object);
        r_object.SetActive(false);
    }

    public GameObject GetCrystal()
    {
        GameObject crystal = newQue.Dequeue();
        crystal.SetActive(true);
        return crystal;
    }
}
