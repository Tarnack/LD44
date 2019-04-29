using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    
    public static Inventory instance;
    [SerializeField]
    public Dictionary<GameObject, List<CurrencySO>> dictionary;


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
        Debug.Log(dictionary.ToString());
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

   // public List<CurrencySO> currencys = new List<CurrencySO>();

    public bool Add (CurrencySO currency, GameObject module)
    {
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

    public Contenu GetContenuTotal()
    {
        Contenu contenu = new Contenu();
        foreach(List<CurrencySO> listSO in dictionary.Values)
        {
            foreach(CurrencySO so in listSO)
                contenu.AddCurr(so);
        }

        return contenu;
    }



}
