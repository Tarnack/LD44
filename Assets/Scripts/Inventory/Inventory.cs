using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }

        instance = this;
    }
    #endregion
    // Update is called once per frame

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;
    public List<CurrencySO> currencys = new List<CurrencySO>();

    public bool Add (CurrencySO currency)
    {
        if (currencys.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }
        currencys.Add(currency);

        if(onItemChangedCallBack != null)
        onItemChangedCallBack.Invoke();

        return true;
    }
    public void Remove (CurrencySO currency)
    {
        currencys.Remove(currency);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }


}
