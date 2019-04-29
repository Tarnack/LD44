using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New WalletModule", menuName = "WalletModule")]
public class WalletModuleSO : ScriptableObject
{
    public int capacityMin;
    public int capacityMax;
    public GameObject prefab;
    public CurrencySO[] content;

    public enum CurrencyType
    {
        Piece, Billet
    }
}
