using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    List<WalletModule> modules = new List<WalletModule>();
    public WalletModuleSO zipper;
    public WalletModuleSO cardHolder;
    public WalletModuleSO billetHolder;
    // Start is called before the first frame update
    public CurrencySO[] startingCurrencies;
    void Start()
    {
        float offsetX = -3;
        float offsetY = -3;
        int[][] positions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2, 2 } };
        int idVisiblePiece = Random.Range(0, 2);
        int idVisibleBillet = Random.Range(0, 2);
        int cpt = 0;
        modules.Add(new WalletModule(zipper, new Vector3(4 + offsetX, 2 + offsetY)));
        modules.Add(new WalletModule(zipper, new Vector3(2 + offsetX, 0 + offsetY)));
        modules.Add(new WalletModule(billetHolder, new Vector3(1 + offsetX, 2 + offsetY)));
        modules.Add(new WalletModule(billetHolder, new Vector3(5 + offsetX, 4 + offsetY)));
        foreach(WalletModule mod in modules)
        {
            if (cpt == idVisiblePiece || cpt == idVisibleBillet + 2)
            {
                mod.SetVisible(false);
            }
            else
                mod.SetVisible(true);
            cpt++;
        }

        foreach (CurrencySO currency in startingCurrencies)
            Debug.Log(Inventory.instance.AddCurrency(currency));
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
