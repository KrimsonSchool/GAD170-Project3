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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned != noToSpawn)
        {
            Instantiate(resourcePrefabs[Random.Range(0, 6)], new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            enemies[spawned] = Instantiate(enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            spawned += 1;
        }
    }
}
