using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour
{
    
    public Transform[] itemsParents;   // The parent object of all the items
    public GameObject inventoryUI; // The entire UI
    public ArrayList moduleActifs;
  

    Inventory inventory;    // Our current inventory

    private InventorySlot[][] slots;  // List of all the slots

    void Start()
    {
        
        moduleActifs = new ArrayList();
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;  // Subscribe to the onItemChanged callback
        slots = new InventorySlot[2][];

        // Populate our slots array

        //call later
        //
    }

    public int Index(InventorySlot slot)
    {
        int index = 0;
        int i = 0;

        foreach (InventorySlot[] s in slots)
        {
            if(s != null)
            {
                foreach (InventorySlot item in s)
                {
                    if (item == slot) index = i;
                }
            }
          

            i++;
        }

        return index;
    }

    void Update()
    {
        // Check to see if we should open/close the inventory
       /* if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }*/
    }

    public void CreationSlot()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        int i = 0;
        foreach (GameObject moduleActif in moduleActifs)
        {

            slots[i] = itemsParents[i].GetComponentsInChildren<InventorySlot>();
            i++;
        }
        
           
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    void UpdateUI()
    {
        int index = 0;
        // Loop through all the slots
        foreach (GameObject moduleActif in moduleActifs)
        {
            for (int i = 0; i < moduleActif.GetComponent<WalletInfos>().capacity; i++)  
            {
                if (i < inventory.dictionary[moduleActif].Count)  // If there is an item to add
                {
                    slots[index][i].AddItem(inventory.dictionary[moduleActif][i]);   // Add it
                }
                else
                {
                    // Otherwise clear the slot
                    slots[index][i].ClearSlot();
                }
            }

            index++;
        }  
    }


    public void ClearInv()
    {
        foreach( InventorySlot[] slot in slots)
            if(slot != null)
                foreach (InventorySlot sl in slot)
                    sl.DestroyGO();
    }

}