using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent pause=new UnityEvent();
    public UnityEvent unpause=new UnityEvent();
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        pause.AddListener(Pause);
        unpause.AddListener(unPause);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            print("Invoke");
            pause?.Invoke();

        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            unpause?.Invoke();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
    }

    public void unPause()
    {
        Time.timeScale = 1;
        paused = false;
    }
}
