using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{

    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
    public InventoryUI invUI;
    private int index;
    private WalletModuleSO walletModule;

    // Start is called before the first frame update
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        invUI = GameObject.Find("Canvas").GetComponent<InventoryUI>();
        myText.color = Color.clear;
        index = 0;
        walletModule = GetComponent<WalletInfos>().so;
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeText ();

        if(Input.GetKeyDown (KeyCode.Escape))
        {
            Cursor.visible = false;
        }
        if(walletModule.locked)
        {
            GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        }
        else
        {
            GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        }
    }

    private void OnMouseDown()
    {

        if (GetComponentsInChildren<SpriteRenderer>()[0].enabled == true)
            return;

        GetComponentsInChildren<SpriteRenderer>()[0].enabled = true;
        index = 3;
        

        DisplayUI[] displays = FindObjectsOfType<DisplayUI>();
        
        
        for (int i = 0; i < displays.Length; i++)
        {
            displays[i].Deselect();
        }
        invUI.ClearInv();
        
        displayInfo = true;
       
        if(invUI.moduleActifs.Count >1)
        {
            invUI.moduleActifs.RemoveAt(0);

        }
        invUI.moduleActifs.Add(gameObject);

        invUI.CreationSlot();
        Inventory.instance.onItemChangedCallBack.Invoke();

    }

    private void OnMouseExit()
    {
        displayInfo = false;
    }

    public void Deselect()
    {
        index--;
        if (index <= 0)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = false;
                
        }
        
    }

    void FadeText()
    {

        if(displayInfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
