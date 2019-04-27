using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletModule
{
    public int pieceCapacity, billetCapacity;
    private bool visibility;
    private GameObject go;
    // Start is called before the first frame update
    public WalletModule(WalletModuleSO so, Vector3 position)
    {
        pieceCapacity = Random.Range(so.pieceCapacityMin, so.pieceCapacityMax);
        billetCapacity = Random.Range(so.billetCapacityMin, so.billetCapacityMax);
        if (pieceCapacity + billetCapacity < 1)
        {
            pieceCapacity = 1;
        }
        go = MonoBehaviour.Instantiate(so.prefab, position, Quaternion.identity);
        go.AddComponent<WalletInfos>();
        go.GetComponent<WalletInfos>().pieceCapacity = pieceCapacity;
        go.GetComponent<WalletInfos>().billetCapacity = billetCapacity;
        Debug.Log("Capacity :  piece  : "+pieceCapacity+"  billet : "+billetCapacity);

        Inventory inventory;
        inventory = Inventory.instance;

        inventory.CreateDictionary(go);
    }


    public void SetVisible(bool visibility)
    {
        this.visibility = visibility;
    }

}
