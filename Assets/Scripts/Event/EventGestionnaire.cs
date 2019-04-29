using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGestionnaire : MonoBehaviour
{

    public EventSO[] listEvent;
    public Text desc;
    public Slider frustration;
    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        desc = GameObject.FindGameObjectWithTag("EventDesc").GetComponent<Text>();
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startNewEvent()
    {
        int numEvent = Random.Range(0, listEvent.Length);

        EventSO newEvent = listEvent[numEvent];
        gameObject.GetComponent<AudioSource>().clip = newEvent.soundTrack;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
        desc.text = newEvent.description;
        if(true)
        frustration.value += newEvent.frustAugment /100;

        if(false)
        frustration.value -= newEvent.frustBaisse /100;
    }
}
