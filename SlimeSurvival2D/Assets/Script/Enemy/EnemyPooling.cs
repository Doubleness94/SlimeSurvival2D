using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public static EnemyPooling instance;

    [SerializeField]
    GameObject manPrefab;
    [SerializeField]
    private Player player;
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
            GameObject manEnemy = Instantiate(instance.manPrefab);
            Enemy enemy = manEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            newQue.Enqueue(manEnemy);
            manEnemy.SetActive(false);
            manEnemy.transform.SetParent(poolParent);
        }
    }

    public void ReturnEnemy(GameObject r_object)
    {
        newQue.Enqueue(r_object);
        r_object.SetActive(false);
    }

    public GameObject GetEnemy()
    {
        GameObject manEnemy = newQue.Dequeue();
        manEnemy.SetActive(true);
        return manEnemy;
    }

}
