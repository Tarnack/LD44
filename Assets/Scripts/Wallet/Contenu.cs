using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenu
{
    public CurrencySO[] listeMonnaieDispo;
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
                float newValue = value - currency.value;
                newContenu.dic = new Dictionary<CurrencySO, int>(possessions.dic);
                newContenu.dic[currency]--;
                try
                {
 
                    List<CurrencySO> paiment = Payer(newValue, newContenu);
                    paiment.Add (currency);
                    float val = value - GetValeur(paiment);
                    if (possibility.ContainsKey(val))
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
                    Debug.Log(e.Message);
                }
            }
        }
        if(possibility.Keys.Count == 0)
        {
            throw new System.Exception("Not enough money");
        }
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
        return val;
    }

    public static List<CurrencySO> RendreMonnaie(float value)
    {
        if (value == 0)
            return new List<CurrencySO>();
        List<CurrencySO> best = null;
        foreach (CurrencySO currency in GameObject.FindObjectOfType<CurrencyList>().GetComponent<CurrencyList>().listCurrency)
        {
            if (currency.value <= value)
            {
                try
                {
                    List<CurrencySO> newSolution = RendreMonnaie(value - currency.value);
                    newSolution.Add(currency);
                    if (newSolution.Count < best.Count)
                        best = newSolution;
                }
                catch
                {

                }
                
            }
        }
        if(best == null)
        {
            throw new System.Exception("Not the necessary currency to make change");
        }
        return best;
    }


}
