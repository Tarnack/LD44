using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour
{
    public GameObject go;
    Transform inventoryPos;

    public void ItemGeneration(Transform inventoryPos)
    {
        Transform parent = GameObject.FindGameObjectWithTag("Parent").transform;
        GameObject gObject = Instantiate(go, inventoryPos.position, Quaternion.identity, parent);
       
    
    }
}
