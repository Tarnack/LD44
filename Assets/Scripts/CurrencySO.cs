using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New currency", menuName ="Currency")]
public class CurrencySO: ScriptableObject
{
    public float value;
    public float taille;
    public CurrencyType type;

    public enum CurrencyType
    {
        Piece, Billet
    }
}
