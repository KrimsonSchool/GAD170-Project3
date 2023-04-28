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
        healthSlider.maxValue = health;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        hp = health;

        if(Random.Range(0, 100) == 1)
        {
            ad.SetActive(true);
        }
        rng = Random.Range(1, 15);
    }

    // Update is called once per frame
    void Update()
    {
        tmr += Time.deltaTime;

        if(tmr>=rng)
        {
            Cursor.visible = true;
            ad.SetActive(true);
            rng = Random.Range(1, 90);
            tmr = 0;
        }

        if (Input.GetMouseButton(1))
        {
            transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        }
        else
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * speed * 100, 0);
        }
        transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed;

        healthSlider.value = health;

        if (Input.GetMouseButton(1))
        {
            gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * (speed * 100), 0);
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

        if (health != hp)
        {
            meshRenderer.material = injuredMat;
            meshRenderer2.material = injuredMat;

            hpTimer += Time.deltaTime;
        }

        if (hpTimer >= 0.3f)
        {
            hpTimer = 0;
            hp = health;
            meshRenderer.material = mainMat;
            meshRenderer2.material = mainMat;
        }

        if (health <= 0)
        {
            Time.timeScale += 0.1f;
            SceneManager.LoadScene(0);
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
