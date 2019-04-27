using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private WalletModule[,] modules;
    public WalletModuleSO defaultModule;
    // Start is called before the first frame update
    void Start()
    {
        int size = 2;
        float offsetX = -2;
        float offsetY = -2;
        modules = new WalletModule[4,4];
        int[][] positions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2, 2 } };
        foreach (int[] pos in positions)
            modules[pos[0], pos[1]] = new WalletModule(defaultModule, new Vector3(pos[0] * size + offsetX , pos[1] * size + offsetY) );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
