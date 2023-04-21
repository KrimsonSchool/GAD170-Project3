using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public Slider healthSlider;
    public GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = health;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        if (Input.GetMouseButton(1))
        {
            gameObject.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }
        else
        {
            turret.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!FindObjectOfType<BuildingManager>().building)
            {
                FindObjectOfType<BuildingManager>().enterBuildingMode();
            }
            else
            {
                FindObjectOfType<BuildingManager>().exitBuildingMode();
                Time.timeScale = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Resource")
        {
            FindObjectOfType<WorldManager>().resource[other.GetComponent<Resource>().type] += 1;
            Destroy(other.gameObject);
        }
    }
}
