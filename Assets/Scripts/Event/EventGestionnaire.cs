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
        background.sprite = newEvent.environnement;

        try
        {
            Contenu.Payer(newEvent.cost, Inventory.instance.GetContenuVisible());
            if (1-frustration.value <= newEvent.frustBaisse / 100)
            {
                List<WalletInfos> modules = new List<WalletInfos>();
                //pete un cable
                foreach (WalletInfos mod in FindObjectsOfType<WalletInfos>())
                {
                    if (!mod.GetComponent<WalletInfos>().visible)
                    {
                        modules.Add(mod);
                    }
                }

                int i = Random.Range(0, modules.Count);
                FindObjectsOfType<WalletInfos>()[i].visible = true;
                
                frustration.value = 0;
            }
            else
            {
                frustration.value += newEvent.frustAugment / 100;
            }
                
        }
        catch (System.Exception e)
        {
            if(frustration.value > newEvent.frustBaisse / 100)
            frustration.value -= newEvent.frustBaisse / 100;
            else
            {
                frustration.value = 0;
            }
           

            
        }
       
    }
}
