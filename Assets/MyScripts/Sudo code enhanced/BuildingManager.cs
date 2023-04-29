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
        //if the building variable is set to true
        if (building)
        {
            //then enable the placement object
            placement.SetActive(true);
            //if (buildings[selected].HasComponent<MeshFilter>())
            //{
            //    placement.GetComponent<MeshFilter>().mesh = buildings[selected].GetComponent<MeshFilter>().sharedMesh;
            //}
            //else if(buildings[selected].GetComponentInChildren<Transform>().gameObject.HasComponent<MeshFilter>())
            //{
            //    placement.GetComponent<MeshFilter>().mesh = buildings[selected].GetComponentInChildren<MeshFilter>().sharedMesh;
            //}

            //reset the text
            resourceText.text = "";

            //set the resourcetext text to display building information
            resourceText.text = "[TAB] to change building, Currently seleccted: " + selectedName[selected] + "\nMetal: " + GetComponent<WorldManager>().resource[0] + "\nOil: " + GetComponent<WorldManager>().resource[1] + "\nPopulation: " + GetComponent<WorldManager>().resource[2] + "\n\n\nCOST:\n";

            //loop for the length of the selected name array variable
            for (int i = 0; i < selectedName.Length; i++)
            {
                //add to the text with the name and cost of the building, loopong through all available buildings
                resourceText.text +="> " + selectedName[i] + "= Metal: " + metalCost[i] + "  Oil: " + oilCost[i] + "  Population: " + populationCost[i]+"\n\n";
            }

            //on left mouse button pressed
            if (Input.GetMouseButtonDown(0))
            {
                //then shoot a ray from the mouse's position in the world
                RaycastHit hit;
                Ray rayOrigin = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

                //if the ray hit something
                if (Physics.Raycast(rayOrigin, out hit))
                {
                    //then if the player has the materials needed to build the selected building
                    if (GetComponent<WorldManager>().resource[0] >= metalCost[selected] && GetComponent<WorldManager>().resource[1] >= oilCost[selected] && GetComponent<WorldManager>().resource[2] >= populationCost[selected])
                    {
                        //then spawn the selected buidling where the mouse's ray hit
                        GameObject obj = Instantiate(buildings[selected], new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity);

                        //rotate the spawned object randomly along the y axis
                        obj.transform.Rotate(0, Random.Range(0, 360), 0);

                        //remove the cost of the building from the players resource pool
                        GetComponent<WorldManager>().resource[0] -= metalCost[selected];
                        GetComponent<WorldManager>().resource[1] -= oilCost[selected];
                        GetComponent<WorldManager>().resource[2] -= populationCost[selected];

                        //increase the cost of that building by 1.2 times so that the game scales in difficulty
                        metalCost[selected] = Mathf.RoundToInt(metalCost[selected] * 1.2f) + 1;
                        oilCost[selected] = Mathf.RoundToInt(oilCost[selected] * 1.2f) + 1;
                        populationCost[selected] = Mathf.RoundToInt(populationCost[selected] * 1.2f) + 1;
                    }
                }
            }
        }
        else
        {
            //if not then disable the placement object
            placement.SetActive(false);
        }

        //if the tab key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //then increase the selected variable by +1
            selected += 1;

            //if the selected variable is greater than the selectedname array variables length
            if (selected > selectedName.Length-1)
            {
                //then set the selected variable to 0
                selected = 0;
            }
        }
    }

    //enterbuildmode function
    public void enterBuildingMode()
    {
        //set the building variable to true
        building = true;
        
        //disable cam 0 and enable cam 1
        cams[0].SetActive(false);
        cams[1].SetActive(true);

        //set the cursor to be visible
        Cursor.visible = true;
    }

    //exitbuildingmode function
    public void exitBuildingMode()
    {
        //set the building variable to false
        building = false;

        //enable cam 0 and disable cam 1
        cams[0].SetActive(true);
        cams[1].SetActive(false);

        //set the cursor to be not visible
        Cursor.visible = false;
    }
}
