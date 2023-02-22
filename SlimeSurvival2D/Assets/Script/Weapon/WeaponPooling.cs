using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPooling : MonoBehaviour
{
    public static WeaponPooling instance;

    [SerializeField]
    GameObject waterGunPrefab;
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
            GameObject waterGun = Instantiate(instance.waterGunPrefab);
            newQue.Enqueue(waterGun);
            waterGun.SetActive(false);
            waterGun.transform.SetParent(poolParent);
        }
    }

    public void ReturnWaterGun(GameObject r_object)
    {
        newQue.Enqueue(r_object);
        r_object.SetActive(false);
    }

    public GameObject GetWaterGun()
    {
        GameObject waterGun = newQue.Dequeue();
        waterGun.SetActive(true);
        return waterGun;
    }
    
}
