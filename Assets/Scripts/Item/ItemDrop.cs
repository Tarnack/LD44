﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public CurrencySO currency;
    private bool wasDropped;
    private int i;

    private void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zipper")
        {
            i++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zipper")
        {
            if (i > 0)
            i--;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!gameObject.GetComponent<DragAndDrop>().isSelected && i == 1)
        {
            DropItem();
        }

    }

    void DropItem()
    {
        Debug.Log("zbub");
        wasDropped = Inventory.instance.Add(currency);

        if (wasDropped)
        {
            Destroy(gameObject);
        }
    }


    
    
   
}
