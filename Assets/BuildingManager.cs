using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public bool building;
    public GameObject[] cams;
    public TMPro.TextMeshProUGUI resourceText;
    public GameObject[] buildings;
    int selected;
    public string[] selectedName;

    public int[] metalCost;
    public int[] oilCost;
    public int[] populationCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (building)
        {
            resourceText.text = "[TAB] to change building, Currently seleccted: "+ selectedName[selected] +"\nMetal: " + GetComponent<WorldManager>().resource[0] + "\nOil: " + GetComponent<WorldManager>().resource[1] + "\nPopulation: " + GetComponent<WorldManager>().resource[2] + "\n\n\nYou can build:\n* Soldier - 1 Metal, 1 - Oil, 1 - Population\n* Barracks - 2 Metal, 1 - Oil, 3 - Population";

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray rayOrigin = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(rayOrigin, out hit))
                {
                    if (GetComponent<WorldManager>().resource[0] >= metalCost[selected] && GetComponent<WorldManager>().resource[1] >= oilCost[selected] && GetComponent<WorldManager>().resource[2] >= populationCost[selected])
                    {
                        Instantiate(buildings[0], new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity);
                        GetComponent<WorldManager>().resource[0] -= metalCost[selected];
                        GetComponent<WorldManager>().resource[1] -= oilCost[selected];
                        GetComponent<WorldManager>().resource[2] -= populationCost[selected];
                    }
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            selected += 1;

            if (selected > 1)
            {
                selected = 0;
            }
        }
    }

    public void enterBuildingMode()
    {
        building = true;
        cams[0].SetActive(false);
        cams[1].SetActive(true);

        Cursor.visible = true;
    }

    public void exitBuildingMode()
    {
        building = false;
        cams[0].SetActive(true);
        cams[1].SetActive(false);

        Cursor.visible = false;

    }
}
