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
        //spawn enemy function
        SpawnEnemy();

        //spawn resoruce function
        SpawnResource();
    }

    // Update is called once per frame
    void Update()
    {
        //is the score greater than the highscore?
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            //if yes, set the highscore to the score
            PlayerPrefs.SetInt("HighScore", score);
        }

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SpawnEnemy();
        //    SpawnResource();
        //}

        //timer = timer + time
        timer += Time.deltaTime;

        //if 90 seconds have passed (1 and a half minutes)
        if (timer >= 90)
        {
            //then set the amount to spawn at 250
            noToSpawn += 250;

            //spawn enemy function
            SpawnEnemy();

            //spawn resource function
            SpawnResource();

            //set timer to 0
            timer = 0;
        }

        //score text = score
        scoreText.text = "Score: " + score;

        //highscore text = highscore
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    //spawn enemy function
    public void SpawnEnemy()
    {
        //loop for amount to spawn
        for (int i = 0; i < noToSpawn; i++)
        {
            //spawn an enemy positionally between -100 and 100 on both the x and z axis and add the enemy to the enemy list
            enemies[spawned] = Instantiate(enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);

            //set the enemies speed to the speed variable
            enemies[spawned].GetComponent<enemy>().speed = speed;

            //set the amount that has been spawned to + 1
            spawned += 1;
        }

        //after the round of spawning the speed variable is 1.3 times itself making the enemies harder each round (every 90 seconds)
        speed *= 1.3f;
    }

    //spawn resource function
    public void SpawnResource()
    {
        //loop for amount to spawn
        for (int i = 0; i < noToSpawn; i++)
        {
            //spawn a resource positionally between -100 and 100 on both the x and z axis
            Instantiate(resourcePrefabs[Random.Range(0, 6)], new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
        }
    }
}
