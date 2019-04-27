using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

    public Image icon;

    // public Button removeButton; // Reference to the remove button
   
    CurrencySO currency;// Current item in the slot

    // Add item to the slot
    public void AddItem(CurrencySO newCurrency)
    {
        currency = newCurrency;

        icon.sprite = currency.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }

    // Clear the slot
    public void ClearSlot()
    {
        currency = null;

        icon.sprite = null;
        icon.enabled = false;
       // removeButton.interactable = false;
    }

    // Called when the remove button is pressed
    public void OnRemoveButton()
    {
        GameObject.FindGameObjectWithTag("Parent").GetComponent<ItemCreation>().ItemGeneration(currency.id, GetComponent<Transform>().position);

    
        Inventory.instance.Remove(currency, GetComponentInParent<InventoryUI>().moduleActif);
    }

    // Called when the item is pressed
   /* public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }*/

}