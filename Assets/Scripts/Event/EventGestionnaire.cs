using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGestionnaire : MonoBehaviour
{

    public EventSO[] listEvent;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();

        startNewEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startNewEvent()
    {
        int numEvent = Random.Range(0, listEvent.Length);
        numEvent = 2;
        EventSO newEvent = listEvent[numEvent];
        gameObject.GetComponent<AudioSource>().clip = newEvent.soundTrack;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
