using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayOrigin = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayOrigin, out hit))
        {
            transform.position = hit.point;
        }
    }
}
