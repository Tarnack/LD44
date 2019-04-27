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
        float offsetX = -2;
        float offsetY = -2;
        modules = new WalletModule[4,4];
        int[][] positions = new int[][] { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2, 2 } };
        int idVisible = Random.Range(0, 3);
        int idCourant = 0;
        foreach (int[] pos in positions)
        {
            modules[pos[0], pos[1]] = new WalletModule(defaultModule, new Vector3(pos[0] * 2 + offsetX, pos[1] * 2 + offsetY));
            if (idCourant == idVisible)
            {
                modules[pos[0], pos[1]].SetVisible(true);
            }
            else {
                modules[pos[0], pos[1]].SetVisible(false);
            }
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
