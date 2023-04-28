using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int type;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 25)
        {
            if (!GetComponent<MeshRenderer>().enabled)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
        }
        else
        {
            if (GetComponent<MeshRenderer>().enabled)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
