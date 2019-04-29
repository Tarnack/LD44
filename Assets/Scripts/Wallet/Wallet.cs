using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private WalletModule[,] modules;
    public WalletModuleSO zipper;
    public WalletModuleSO cardHolder;
    public WalletModuleSO billetHolder;
    // Start is called before the first frame update
    void Start()
    {
        float offsetX = -3;
        float offsetY = -3;
        List<WalletModule> modules = new List<WalletModule>();
        int[][] positions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2, 2 } };
        int idVisible = Random.Range(0, 3);
        int idCourant = 0;
        modules.Add(new WalletModule(zipper, new Vector3(0 + offsetX, 0 + offsetY)));
        modules.Add(new WalletModule(zipper, new Vector3(2 + offsetX, 0 + offsetY)));
        modules.Add(new WalletModule(billetHolder, new Vector3(1 + offsetX, 2 + offsetY)));
        foreach (WalletModule mod in modules)
        {
            if (idCourant == idVisible)
            {
                mod.SetVisible(true);
            }
            else {
                mod.SetVisible(false);
            }
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
