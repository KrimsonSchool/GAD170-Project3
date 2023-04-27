using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor.PackageManager;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject placement;
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
            placement.SetActive(true);
            //if (buildings[selected].HasComponent<MeshFilter>())
            //{
            //    placement.GetComponent<MeshFilter>().mesh = buildings[selected].GetComponent<MeshFilter>().sharedMesh;
            //}
            //else if(buildings[selected].GetComponentInChildren<Transform>().gameObject.HasComponent<MeshFilter>())
            //{
            //    placement.GetComponent<MeshFilter>().mesh = buildings[selected].GetComponentInChildren<MeshFilter>().sharedMesh;
            //}

            resourceText.text = "";
            resourceText.text = "[TAB] to change building, Currently seleccted: "+ selectedName[selected] +"\nMetal: " + GetComponent<WorldManager>().resource[0] + "\nOil: " + GetComponent<WorldManager>().resource[1] + "\nPopulation: " + GetComponent<WorldManager>().resource[2] + "\n\n\nCOST:\n";
            for (int i = 0; i < selectedName.Length; i++)
            {
                resourceText.text +="> " + selectedName[i] + "= Metal: " + metalCost[i] + "  Oil: " + oilCost[i] + "  Population: " + populationCost[i]+"\n\n";
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray rayOrigin = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(rayOrigin, out hit))
                {
                    if (GetComponent<WorldManager>().resource[0] >= metalCost[selected] && GetComponent<WorldManager>().resource[1] >= oilCost[selected] && GetComponent<WorldManager>().resource[2] >= populationCost[selected])
                    {
                        Instantiate(buildings[selected], new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity);
                        GetComponent<WorldManager>().resource[0] -= metalCost[selected];
                        GetComponent<WorldManager>().resource[1] -= oilCost[selected];
                        GetComponent<WorldManager>().resource[2] -= populationCost[selected];

                        metalCost[selected] = Mathf.RoundToInt(metalCost[selected] * 1.2f) + 1;
                        oilCost[selected] = Mathf.RoundToInt(oilCost[selected] * 1.2f) + 1;
                        populationCost[selected] = Mathf.RoundToInt(populationCost[selected] * 1.2f) + 1;
                    }
                }
            }
        }
        else
        {
            placement.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            selected += 1;

            if (selected > selectedName.Length-1)
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
