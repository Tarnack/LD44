using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenu : MonoBehaviour
{
    private Dictionary<CurrencySO, int> dic = new Dictionary<CurrencySO, int>();
    

    public float getValue()
    {
        float somme = 0;
        foreach (CurrencySO curren in dic.Keys)
            somme += curren.value * dic[curren];
        return somme;
    }



}
