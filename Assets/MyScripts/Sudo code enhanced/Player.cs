using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
using UnityEditor.Advertisements;

public class Player : MonoBehaviour
{
    public int health;
    public Slider healthSlider;
    public GameObject turret;

    public Material mainMat;
    public Material injuredMat;
    public MeshRenderer meshRenderer;
    public MeshRenderer meshRenderer2;
    float hpTimer;

    int hp;

    public float speed;

    public GameObject ad;

    float tmr;
    int rng;
    // Start is called before the first frame update
    void Start()
    {
        //set the health sliders max to players health
        healthSlider.maxValue = health;

        //make the cursor not visible and locked to the playable window
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        //variable hp is set to players health
        hp = health;

        //1% chance for an ad to play when the game starts
        if(Random.Range(0, 100) == 1)
        {
            ad.SetActive(true);
        }
        
        //rng variable is set to a random value between 1 and 15
        rng = Random.Range(1, 15);
    }

    // Update is called once per frame
    void Update()
    {
        //tmr = tmr + time
        tmr += Time.deltaTime;

        //if tmr is greater or equal to rng variable's value
        if(tmr>=rng)
        {
            //then set the cursor to be visible
            Cursor.visible = true;

            //show the ad
            ad.SetActive(true);

            //re-randomise rng variable
            rng = Random.Range(1, 15);

            //set tmr to 0
            tmr = 0;
        }

        //if right mouse button down
        if (Input.GetMouseButton(1))
        {
            //then players right to left position is + horizontal axis key values times by speed variable
            transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;

            //player y rotation is set to mouse x axis value
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }
        else
        {
            //if not then players y rotation is set to horizontal axis key values times by speed variable times by 50
            transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * speed * 50, 0);
            
            //turret y rotation is set to mouse x axis value
            turret.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }

        //players forward to backward position is + vertical axis key values times by speed variable 
        transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //health slider value is set to health variable value
        healthSlider.value = health;

        //if Q key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //if not building
            if (!FindObjectOfType<BuildingManager>().building)
            {
                //then run function enterbuildingmode
                FindObjectOfType<BuildingManager>().enterBuildingMode();
            }
            else
            {
                //if not run function exit building mode
                FindObjectOfType<BuildingManager>().exitBuildingMode();

                //set time scale to be 1
                Time.timeScale = 1;
            }
        }

        //if health variable does not equal hp variable
        if (health != hp)
        {
            //then set players material to be injured material
            meshRenderer.material = injuredMat;
            meshRenderer2.material = injuredMat;

            //set hptimer to be hptimer + time
            hpTimer += Time.deltaTime;
        }

        //if hptimer variable is greater or equal to 0.3
        if (hpTimer >= 0.3f)
        {
            //then set hptimer to be 0
            hpTimer = 0;

            //hp variable equals health variable
            hp = health;

            //set players material to be normal material
            meshRenderer.material = mainMat;
            meshRenderer2.material = mainMat;
        }

        //if health variable is equal or less than 0
        if (health <= 0)
        {
            //then increase timescale by 0.1
            Time.timeScale += 0.1f;

            //reload game scene
            SceneManager.LoadScene(0);
        }
    }

    //on trigger enter other object
    private void OnTriggerEnter(Collider other)
    {
        //if other objects tag is "Resource"
        if(other.tag == "Resource")
        {
            //then give resource of type of other object
            FindObjectOfType<WorldManager>().resource[other.GetComponent<Resource>().type] += 1;

            //delete other object
            Destroy(other.gameObject);
        }
    }
}
