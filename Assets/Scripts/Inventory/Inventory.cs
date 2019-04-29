using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region Singleton
    
    public static Inventory instance;
    [SerializeField]
    public Dictionary<GameObject, List<CurrencySO>> dictionary;
    public Text totalMoney, visibleMoney;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }

        instance = this;

        dictionary = new Dictionary<GameObject, List<CurrencySO>>();
    }
    #endregion
    // Update is called once per frame

   
    

    private void Start()
    {

       
    }

    public void CreateDictionary(GameObject go)
    {
    
       dictionary.Add(go, new List<CurrencySO>());
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

   // public List<CurrencySO> currencys = new List<CurrencySO>();

    public bool Add (CurrencySO currency, GameObject module)
    {
        bool contentOK = false;

        foreach (CurrencySO possibleContent in module.GetComponent<WalletInfos>().so.content)
            contentOK |= currency.id == possibleContent.id;
        if (!contentOK)
        {
            Debug.Log("Ba type of content");
            return false;
        }

        if (dictionary[module].Count >= module.GetComponent<WalletInfos>().capacity )
        {
            Debug.Log("Not enough room");
            return false;
        }
        dictionary[module].Add(currency);

        if(onItemChangedCallBack != null)
        onItemChangedCallBack.Invoke();


        return true;
    }
    public void Remove (CurrencySO currency, GameObject module)
    {
        dictionary[module].Remove(currency);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

    public void UpdateContenu()
    {
        Contenu contenuTotal = new Contenu();
        Contenu contenuVisible = new Contenu();
        foreach (GameObject module in dictionary.Keys)
        {
            foreach(CurrencySO so in dictionary[module])
            {
                contenuTotal.AddCurr(so);
                if (module.GetComponent<WalletInfos>().visible)
                {
                    contenuVisible.AddCurr(so);
                }
            }
        }
        totalMoney.text = "Total money : " + contenuTotal.GetValue();
        visibleMoney.text = "Visible money : " + contenuVisible.GetValue();
    }


}
