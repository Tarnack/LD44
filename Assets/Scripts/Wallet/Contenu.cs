﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenu
{
    private Dictionary<CurrencySO, int> dic = new Dictionary<CurrencySO, int>();
    

    public void AddCurr(CurrencySO curr)
    {
        if (dic.ContainsKey(curr))
            dic[curr]++;
        else
            dic[curr] =  1;
    }

    public float GetValue()
    {
        float somme = 0;
        foreach (CurrencySO curren in dic.Keys)
            somme += curren.value * dic[curren];

        return somme;
    }



}
