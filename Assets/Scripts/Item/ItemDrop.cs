using System.Collections;
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


        if(i ==1)
        {
            if (other.tag == "Zipper")
            {
                wasDropped = Inventory.instance.Add(currency, other.gameObject);
            }
        }

        else
        {
            if (GetComponent<ItemSlotOrigin>().lastModule != null)
                wasDropped = Inventory.instance.Add(currency, GetComponent<ItemSlotOrigin>().lastModule);
        }


        if (wasDropped)
        {
            Destroy(gameObject);
        }
    }


    
    
   
}
