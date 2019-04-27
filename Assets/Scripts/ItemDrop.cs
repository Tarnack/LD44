using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Item item;
    private bool wasDropped;

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!gameObject.GetComponent<DragAndDrop>().isSelected)
        {
            DropItem(); 
        }
       
    }

    void DropItem()
    {
        Debug.Log("zbub");
        wasDropped = Inventory.instance.Add(item);

        if (wasDropped)
        {
            Destroy(gameObject);
        }
    }


    
    
   
}
