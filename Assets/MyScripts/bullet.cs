using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bullet : MonoBehaviour
{
    WorldManager worldManager;
    public float dist;
    public GameObject selected;
    public float speed;
    int id;
    // Start is called before the first frame update
    void Start()
    {
        worldManager = FindObjectOfType<WorldManager>();
        dist = 999999999999;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < worldManager.enemies.Length; i++)
        {
            if (worldManager.enemies[i] != null)
            {
                if (Vector3.Distance(worldManager.enemies[i].transform.position, transform.position) < dist)
                {
                    dist = Vector3.Distance(worldManager.enemies[i].transform.position, transform.position);
                    selected = worldManager.enemies[i];
                    id = i;
                }
            }
        }

        if (selected != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(selected.transform.position.x, selected.transform.position.y + 1.75f, selected.transform.position.z), Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }

        if (dist <= 0.1f)
        {
            worldManager.enemies[id] = null;
            Destroy(selected);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
