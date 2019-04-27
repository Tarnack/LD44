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
    // Start is called before the first frame update
    void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;
        
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
        displayInfo = true;
        invUI.moduleActif = GetComponent<GameObject>();
        Debug.Log("coucou");
    }

    private void OnMouseExit()
    {
        displayInfo = false;
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
