using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New WalletModule", menuName = "WalletModule")]
public class WalletModuleSO : ScriptableObject
{
    public int pieceCapacityMin;
    public int pieceCapacityMax;
    public int billetCapacityMin;
    public int billetCapacityMax;
    public GameObject prefab;

    public enum CurrencyType
    {
        Piece, Billet
    }
}
