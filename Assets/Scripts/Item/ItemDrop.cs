﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public CurrencySO currency;
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
        if (!gameObject.GetComponent<DragAndDrop>().isSelected)
        {
            DropItem(other);
           
            
            
        }

    }



    void DropItem(Collider other)
    {
        /* if(other.tag != "Zipper")
         {
             //
         }*/
        bool wasDropped = false;
        bool remove = true;
        if(i ==1)
        {
            if (other.tag == "Zipper")
            {
                if (GetComponent<ItemSlotOrigin>().lastModule == null || GetComponent<ItemSlotOrigin>().lastModule.GetComponent<Collider>() != other)
                    remove = Inventory.instance.Add(currency, other.gameObject);
                else
                    remove = false;
            wasDropped = true;
            }
        }

        else
        {
            if (GetComponent<ItemSlotOrigin>().lastModule != null)
            {
                remove = false;
                wasDropped = true;
            }
        }


        if (wasDropped)
        {
            Destroy(gameObject);
            Inventory.instance.Remove(currency, GetComponent<ItemSlotOrigin>().lastModule);
            if (!remove)
                Inventory.instance.Add(currency, GetComponent<ItemSlotOrigin>().lastModule);
        }
    }


    
    
   
}
