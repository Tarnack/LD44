using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletModule
{
    public int pieceCapacity, billetCapacity;
    // Start is called before the first frame update
    public WalletModule(WalletModuleSO so, Vector3 position)
    {
        MonoBehaviour.Instantiate(so.prefab, position, Quaternion.identity);
        pieceCapacity = Random.Range(so.pieceCapacityMin, so.pieceCapacityMax);
        billetCapacity = Random.Range(so.billetCapacityMin, so.billetCapacityMax);
        if(pieceCapacity + billetCapacity < 1)
        {
            pieceCapacity = 1;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
