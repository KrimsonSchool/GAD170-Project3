using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    Quaternion endValue;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<EventManager>().pause.AddListener(Pause);
        FindObjectOfType<EventManager>().unpause.AddListener(unPause);

        endValue = new Quaternion(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        float duration = 3;
        float time = 0;
        Quaternion startValue = transform.rotation;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
        }
        transform.rotation = endValue;
    }

    public void Pause()
    {
        print("Pause");
    }

    public void unPause()
    {
        print("UnPause");
    }
}
