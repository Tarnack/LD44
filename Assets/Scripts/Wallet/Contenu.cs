using System.Collections;
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
            dic[curr] = 1;
    }

    public float GetValue()
    {
        float somme = 0;
        foreach (CurrencySO curren in dic.Keys)
            somme += curren.value * dic[curren];

        return somme;
    }



    public static List<CurrencySO> Payer(float value, Contenu possessions)
    {
        if (value <= 0)
            return new List<CurrencySO>();
        Dictionary<float, List<CurrencySO>> possibility = new Dictionary<float, List<CurrencySO>>();
        foreach (CurrencySO currency in possessions.dic.Keys)
        {
            if (possessions.dic[currency] > 0)
            {
                Contenu newContenu = new Contenu();
                newContenu.dic = new Dictionary<CurrencySO, int>(possessions.dic);
                newContenu.dic[currency]--;
                try
                {
                    Debug.Log("Da Way");
                    List<CurrencySO> paiment = Payer(value - currency.value, newContenu);
                    paiment.Add (currency);

                    float val;
                    if (possibility.ContainsKey(val = GetValeur(paiment)))
                    {
                        if (possibility[val].Count < paiment.Count)
                        {
                            possibility[val] = paiment;
                        }
                    }
                    else
                    {
                        possibility.Add(val, paiment);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.StackTrace);
                }
            }
        }
        if(possibility.Count ==0 )
            throw new System.Exception("Not enough money");
        float best = float.NegativeInfinity;
        List<CurrencySO> bestList = null;
        foreach(float f in possibility.Keys)
        {
            if (f > best){
                best = f;
                bestList = possibility[f];
            }
        }
        return bestList;
    }


    private static float GetValeur(List<CurrencySO> paiment){
        float val = 0;
        foreach (CurrencySO curr in paiment)
        {
            val += curr.value;
        }
        return 0;
    }



}
