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
        myText = GameObject.Find("Text").GetComponent<Text>();
        invUI = GameObject.Find("Canvas").GetComponent<InventoryUI>();
        myText.color = Color.clear;
        index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeText ();

        if(Input.GetKeyDown (KeyCode.Escape))
        {
            Cursor.visible = false;
        }
    }

    private void OnMouseDown()
    {

        if (GetComponentInChildren<SpriteRenderer>().enabled == true)
            return;
        
        GetComponentInChildren<SpriteRenderer>().enabled = true;
        index = 3;
        

        DisplayUI[] displays = FindObjectsOfType<DisplayUI>();
        
        
            for (int i = 0; i < displays.Length; i++)
            {
               
                displays[i].Deselect();

            }
          
     


        displayInfo = true;
       
        if(invUI.moduleActifs.Count >1)
        {
            invUI.moduleActifs.RemoveAt(0);

        }
        invUI.moduleActifs.Add(gameObject);

        invUI.CreationSlot();


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
            
        else
        {

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
