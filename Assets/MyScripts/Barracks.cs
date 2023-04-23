using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    float timer;
    public GameObject soldier;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            Instantiate(soldier, spawn.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
