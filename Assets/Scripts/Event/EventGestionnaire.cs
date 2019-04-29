using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventGestionnaire : MonoBehaviour
{

    public EventSO[] listEvent;
    public Text desc;
    public Text prix;
    public Slider frustration;
    public Slider sliderTimer;
    public Image background;
    private float timerInit;
    private float timer;
    private EventSO newEvent;
    public int eventPassed;
    public Text gameOverScore;
   


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        desc = GameObject.FindGameObjectWithTag("EventDesc").GetComponent<Text>();
   
    

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sliderTimer.value = (timerInit - timer) / timerInit;

        if(timer>=timerInit)
        {
            FinEvent();
        }
    }


    public void StartNewEvent()
    {
        int numEvent = Random.Range(0, listEvent.Length);

        newEvent = listEvent[numEvent];
        gameObject.GetComponent<AudioSource>().clip = newEvent.soundTrack;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();
        desc.text = newEvent.description;
        prix.text = "Will cost you : ";
        prix.text += newEvent.cost;
        background.sprite = newEvent.environnement;
        timerInit = newEvent.timer;
        timer = 0;
             
    }

    private void FinEvent()
    {
        try
        {
            float aPayer = newEvent.cost;
            List<CurrencySO> aRetirer = Contenu.Payer(aPayer, Inventory.instance.GetContenuVisible());
            foreach (CurrencySO currencyARetirer in aRetirer)
            {
                Inventory.instance.RemoveCurrency(currencyARetirer);
                aPayer -= currencyARetirer.value;

            }
            if (aPayer < 0)
            {
                Debug.Log("Rendu : " + -aPayer);
                List<CurrencySO> aRendre = Contenu.RendreMonnaie(-aPayer);
                foreach (CurrencySO currencyARetirer in aRendre)
                {
                    Inventory.instance.AddCurrency(currencyARetirer);

                }
            }
            if (1 - frustration.value <= newEvent.frustBaisse / 100)
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
        catch
        {
            if (frustration.value > newEvent.frustBaisse / 100)
                frustration.value -= newEvent.frustBaisse / 100;
            else
            {
                frustration.value = 0;
            }


        }
        eventPassed++;
        gameOverScore.text = "You survived to " + eventPassed + " events";
        StartNewEvent();
    }
}
