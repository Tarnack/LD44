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
   

    // Start is called before the first frame update
    void Start()
    {

        myText = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
        invUI = GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryUI>();

        myText.color = Color.clear;

       
        index = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myText != null)
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);

        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Cursor.visible = false;
        }
        if(!GetComponent<WalletInfos>().visible)
        {
            GetComponentsInChildren<SpriteRenderer>()[1].enabled = true;
        }
        else
        {
            GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        }
        if (GetComponentsInChildren<SpriteRenderer>()[0].enabled == true)
        {
            GetComponentsInChildren<SpriteRenderer>()[0].color = invUI.itemsParents[index-1].GetComponentInChildren<RawImage>().color;
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
    
    public void FadeText(string myString)
    {


        //myText.text = myString;
        if (myText != null)
        {
            myText.text = myString;
            myText.color = Color.red;
        }

    }
    
}
