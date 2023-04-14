using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public int[]resource;
    public GameObject[] enemies;

    public GameObject enemyPrefab;
    public GameObject soldierPrefab;

    public GameObject[] resourcePrefabs;
    public int noToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (noToSpawn != 0)
        {
            Instantiate(resourcePrefabs[Random.Range(0, 6)], new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            enemies[noToSpawn] = Instantiate(enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            noToSpawn -= 1;
        }
    }
}
