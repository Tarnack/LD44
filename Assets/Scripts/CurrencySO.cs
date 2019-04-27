using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New currency", menuName ="Currency")]
public class CurrencySO: ScriptableObject
{
    public float value;
    public float taille;
    public Sprite icon;
    public CurrencyType type;
    public int id;

    public enum CurrencyType
    {
        Piece, Billet
    }
}
