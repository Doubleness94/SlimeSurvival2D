using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    GameObject manPrefab;
    [SerializeField]
    GameObject womanPrefab;

    [SerializeField]
    GameObject waterGunPrefab;
    [SerializeField]
    GameObject magicCirclePrefab;

    [SerializeField] 
    GameObject blueCrystalPrefab;
    [SerializeField] 
    GameObject greenCrystalPrefab;
    [SerializeField] 
    GameObject redCrystalPrefab;

    static ObjectPooling instance;
    Dictionary<string, Queue<GameObject>> poolingDict = new Dictionary<string, Queue<GameObject>>();

    const int initNumEnemy = 500;
    const int initNumWeapon = 500;
    const int initNumCrystal = 500;
    public Queue<GameObject> newQue = new Queue<GameObject>();

    void Awake()
    {
        instance = this;
        EnemyInsert();
        WeaponInsert();
        CrystalInsert();
    }

    void EnemyInsert()
    {
        Queue<GameObject> newQue = new Queue<GameObject>();
        for (int i = 0; i < initNumEnemy; i++)
        {
            GameObject enemyMan = Instantiate(instance.manPrefab);
            newQue.Enqueue(enemyMan);
            enemyMan.SetActive(false);
        }       
    }
    
    void WeaponInsert()
    {
        Queue<GameObject> newQue = new Queue<GameObject>();
        for (int i = 0; i < initNumWeapon; i++)
        {
            GameObject waterGun = Instantiate(instance.waterGunPrefab);
            newQue.Enqueue(waterGun);
            waterGun.SetActive(false);
        }
    }

    void CrystalInsert()
    {
        Queue<GameObject> newQue = new Queue<GameObject>();
        for (int i = 0; i < initNumCrystal; i++)
        {
            GameObject crystal = Instantiate(instance.blueCrystalPrefab);
            newQue.Enqueue(crystal);
            crystal.SetActive(false);
        }
    }

    public void ReturnObject(GameObject back)
    {
        newQue.Enqueue(back);
        back.SetActive(false);
    }

    
}
