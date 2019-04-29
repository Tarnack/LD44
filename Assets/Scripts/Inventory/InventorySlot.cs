using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

    public Image icon;//icon
    private InventoryUI invUI;
    private GameObject temporary;

    // public Button removeButton; // Reference to the remove button

    CurrencySO currency;// Current item in the slot

    private void Start()
    {
        invUI = FindObjectOfType<InventoryUI>();
    }

    // Add item to the slot
    public void AddItem(CurrencySO newCurrency)
    {
       
        currency = newCurrency;

        icon.sprite = currency.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
        if (temporary != null) Destroy(temporary);


        temporary = GameObject.FindGameObjectWithTag("Parent").GetComponent<ItemCreation>().ItemGeneration(GetComponent<Transform>().position, currency.model, currency.taille);
        temporary.GetComponent<ItemSlotOrigin>().lastModule = (GameObject)GetComponentInParent<InventoryUI>().moduleActifs[invUI.Index(this)];
        temporary.GetComponent<ItemDrop>().currency = currency;
      
    }

    // Clear the slot
    public void ClearSlot()
    {
        currency = null;

        icon.sprite = null;
        icon.enabled = false;
        // removeButton.interactable = false;
        Destroy(temporary);
    }


    // Called when the item is pressed
   /* public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }*/
    public void DestroyGO()
    {
        Destroy(temporary);
    }

}