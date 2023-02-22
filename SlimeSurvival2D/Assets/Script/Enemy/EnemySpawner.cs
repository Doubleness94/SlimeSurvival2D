using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    [SerializeField]
    Transform player;
    float spawnDelay;

    float maxX = 5;
    float maxY = 8;

    public int enemyCount;

    enum Direction
    {
        North,
        South,
        West,
        East
    }
    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
        enemyCount = 0;
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Initialize()
    {
        spawnDelay = 0.5f;
    }

    IEnumerator SpawnEnemy()
    {        
        while(enemyCount < 400)
        {
            GameObject newEnemy;
            newEnemy = EnemyPooling.instance.GetEnemy();
            newEnemy.transform.position = RandomPosition();
            newEnemy.SetActive(true);
            enemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
        
    }

    Vector3 RandomPosition()
    {
        Vector3 pos = new Vector3();

        Direction direction = (Direction)Random.Range(0, 4);
        switch (direction)
        {
            case Direction.North:
                pos.x = Random.Range(player.transform.position.x - maxX, player.transform.position.x + maxX);
                pos.y = player.transform.position.y + 10f;
                break;
            case Direction.South:
                pos.x = Random.Range(player.transform.position.x - maxX, player.transform.position.x + maxX);
                pos.y = player.transform.position.y - 10f;
                break;
            case Direction.West:
                pos.x = player.transform.position.x - 5f;
                pos.y = Random.Range(player.transform.position.y - maxY, player.transform.position.y + maxY);
                break;
            case Direction.East:
                pos.x = player.transform.position.x + 5f;
                pos.y = Random.Range(player.transform.position.y - maxY, player.transform.position.y + maxY);
                break;
        }
        return pos;
    }
}
