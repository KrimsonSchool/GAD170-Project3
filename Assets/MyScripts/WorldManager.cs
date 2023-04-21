using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public int[]resource;

    public GameObject enemyPrefab;
    public GameObject soldierPrefab;
    public GameObject[] enemies;

    public GameObject[] resourcePrefabs;
    public int noToSpawn;
    public int spawned;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        SpawnResource();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
            SpawnResource();
        }
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < noToSpawn; i++)
        {
            enemies[spawned] = Instantiate(enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            spawned += 1;
        }
    }
    public void SpawnResource()
    {
        for (int i = 0; i < noToSpawn; i++)
        {
            Instantiate(resourcePrefabs[Random.Range(0, 6)], new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
        }
    }
}
