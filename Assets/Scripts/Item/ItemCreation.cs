using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour
{
    public GameObject[] gObjects;
   

    public GameObject ItemGeneration(int index, Vector3 itemPos)
    {
        
        GameObject go = Instantiate(gObjects[index], new Vector3(itemPos.x, itemPos.y, -2), Quaternion.identity);
        go.GetComponent<DragAndDrop>().isSelected = true;
        return go;

    }
}
