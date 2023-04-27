using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{
    GameObject player;
    public WorldManager worldManager;
    GameObject enemy;
    public GameObject bullet;
    public GameObject bulletSpawn;
    float timer;
    float lifeTimer;
    float animTimer;
    bool shooting;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;

        worldManager = FindObjectOfType<WorldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        lifeTimer += Time.deltaTime;
        //print(timer);
        if (Vector3.Distance(player.transform.position, transform.position) > 5)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position - transform.forward * 2;
        }

        for (int i = 0; i < worldManager.enemies.Length; i++)
        {
            //print("Searching");
            enemy = worldManager.enemies[i];

            if (enemy != null)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) > 7)
                {
                    //print("Too Far Away!");
                }
                else
                {
                    if (timer >= 0.5f)
                    {
                        Shoot();
                        timer = 0;
                        break;
                    }
                }
            }
        }

        if (lifeTimer >= 5)
        {
            Destroy(gameObject);
        }

        if (shooting)
        {
            animTimer += Time.deltaTime;

            if(animTimer > 0.5f)
            {
                GetComponent<Animator>().SetBool("shoot", false);
                animTimer = 0;
                shooting = false;
            }
        }
    }

    public void Shoot()
    {
        shooting = true;
        GetComponent<Animator>().SetBool("shoot", true);
        Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
    }
}
