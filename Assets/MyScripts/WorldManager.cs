using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScoreText;

    public int[]resource;

    public GameObject enemyPrefab;
    public GameObject soldierPrefab;
    public GameObject[] enemies;

    public GameObject[] resourcePrefabs;
    public int noToSpawn;
    public int spawned;
    float timer;

    public int score;

    int hs;
    float speed=5;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        SpawnResource();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
            SpawnResource();
        }

        timer += Time.deltaTime;

        if (timer >= 90)
        {
            noToSpawn += 250;
            SpawnEnemy();
            SpawnResource();
            timer = 0;
        }

        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < noToSpawn; i++)
        {
            enemies[spawned] = Instantiate(enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            enemies[spawned].GetComponent<enemy>().speed = speed;
            spawned += 1;
        }

        speed *= 1.3f;
    }
    public void SpawnResource()
    {
        for (int i = 0; i < noToSpawn; i++)
        {
            Instantiate(resourcePrefabs[Random.Range(0, 6)], new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
        }
    }
}
