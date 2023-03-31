using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent pause; 
    // Start is called before the first frame update
    void Start()
    {
        if (pause == null)
        {
            pause = new UnityEvent();
        }
        pause.AddListener(Pause);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause?.Invoke();
        }
    }

    public void Pause()
    {

    }
}
