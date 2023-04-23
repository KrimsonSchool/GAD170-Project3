using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ResourceGenerator : MonoBehaviour
{
    public int resource;
    public float secs;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= secs)
        {
            FindObjectOfType<WorldManager>().resource[resource] += 1;
        }
    }
}
