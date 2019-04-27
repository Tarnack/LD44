using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletModule
{

    // Start is called before the first frame update
    public WalletModule(WalletModuleSO so, Vector3 position)
    {
        MonoBehaviour.Instantiate(so.prefab, position, Quaternion.identity);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
