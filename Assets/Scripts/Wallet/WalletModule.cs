using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletModule
{
    public int capacity;
    private bool visibility;
    private GameObject go;
    // Start is called before the first frame update
    public WalletModule(WalletModuleSO so, Vector3 position)
    {
        capacity = Random.Range(so.capacityMin, so.capacityMax);

        go = MonoBehaviour.Instantiate(so.prefab, position, Quaternion.identity);
        go.AddComponent<WalletInfos>();
        go.GetComponent<WalletInfos>().capacity = capacity;
        go.GetComponent<WalletInfos>().so = so;
        Debug.Log("Capacity : "+ capacity);

        Inventory inventory;
        inventory = Inventory.instance;

        inventory.CreateDictionary(go);
    }


    public void SetVisible(bool visibility)
    {
        this.visibility = visibility;
    }

}
