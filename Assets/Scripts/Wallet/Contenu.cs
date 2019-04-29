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



    public static List<CurrencySO> payer(float value, Contenu possessions)
    {
        if (value <= 0)
            return new List<CurrencySO>();

        else
        {
            bool currFound = false;
            Dictionary<float, List<CurrencySO>> possibility = new Dictionary<float, List<CurrencySO>>();
            foreach (CurrencySO currency in possessions.dic.Keys)
            {
                if (possessions.dic[currency] > 0)
                {
                    currFound = true;
                    Contenu newContenu = new Contenu();
                    newContenu.dic = new Dictionary<CurrencySO, int>(possessions.dic);
                    newContenu.dic[currency]--;
                    List<CurrencySO> paiment = payer(value - currency.value, newContenu);

                }
            }
        }
        return new List<CurrencySO>();
    }


    private static float getValeur(List<CurrencySO> paiment){
        return 0;
    }



}
