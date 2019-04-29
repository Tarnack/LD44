using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour
{
    public GameObject gObjects;
   
   

    public GameObject ItemGeneration(Vector3 itemPos, GameObject model, float size)
    {
        
        GameObject go = Instantiate(gObjects, new Vector3(itemPos.x, itemPos.y, -2), Quaternion.identity);
        GameObject model3d = Instantiate(model, new Vector3(itemPos.x, itemPos.y, -2), Quaternion.identity, go.transform);
        model3d.transform.localScale = new Vector3(model3d.transform.localScale.x * size, model3d.transform.localScale.y * size, model3d.transform.localScale.z * size);
        go.GetComponent<DragAndDrop>().isSelected = true;
        return go;

    }
}
