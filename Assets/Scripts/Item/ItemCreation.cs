using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreation : MonoBehaviour
{
    public GameObject[] gObjects;
   

    public void ItemGeneration(int index, Vector3 itemPos)
    {
        //Transform parent = GameObject.FindGameObjectWithTag("Parent").transform;
        Instantiate(gObjects[index], new Vector3(itemPos.x, itemPos.y, -2), Quaternion.identity);


    }
}
