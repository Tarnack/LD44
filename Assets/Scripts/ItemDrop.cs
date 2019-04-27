using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public Item item;
    private bool wasPickedUp;

    private void Update()
    {
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!gameObject.GetComponent<DragAndDrop>().isSelected)
        {
            Debug.Log("zbub");
            wasPickedUp = Inventory.instance.Add(item);
        }
       
    }

    
    
   
}
