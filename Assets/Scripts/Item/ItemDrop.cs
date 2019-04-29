using System.Collections;
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
        if (other.gameObject.GetComponent<WalletInfos>() != null || other.tag == "Inventory" || other.tag == "Inventory2" )
        {
            i++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<WalletInfos>() != null || other.tag == "Inventory" || other.tag == "Inventory2" )
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



        if (i ==1)
        {
      

            if (other.tag == "Inventory")
            {

                if (GetComponent<ItemSlotOrigin>().lastModule != (GameObject)GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryUI>().moduleActifs[0])
                    remove = Inventory.instance.Add(currency, (GameObject)GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryUI>().moduleActifs[0]);
                //if(!remove)
                else
                    remove = false;
                wasDropped = true;

            }

            if (other.tag == "Inventory2")
            {

                if (GetComponent<ItemSlotOrigin>().lastModule != (GameObject)GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryUI>().moduleActifs[1])
                    remove = Inventory.instance.Add(currency, (GameObject)GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryUI>().moduleActifs[1]);
                else
                    remove = false;
                wasDropped = true;

            }

            if (other.gameObject.GetComponent<WalletInfos>() != null)
            {
                if (GetComponent<ItemSlotOrigin>().lastModule.GetComponent<Collider>() != other)
                    remove = Inventory.instance.Add(currency, other.gameObject);
                else
                    remove = false;
            wasDropped = true;
            }
        }

        else
        {
            
              remove = false;
              wasDropped = true;
            
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
