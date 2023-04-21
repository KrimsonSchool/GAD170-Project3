using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    GameObject player;
    float hitTimer;
    public GameObject meshes;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (Vector3.Distance(player.transform.position, transform.position) < 15)
        {
            GetComponent<NavMeshAgent>().speed = 5;
            if (!meshes.activeSelf)
            {
                meshes.SetActive(true);
            }
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = 1;
            if (meshes.activeSelf)
            {
                meshes.SetActive(false);
            }
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= 2)
        {
            //print("ATTACK");

            hitTimer += Time.deltaTime;

            if (hitTimer >= 1)
            {
                player.GetComponent<Player>().health -= 5;
                hitTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);
        }
    }
}
