using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyFactory : MonoBehaviour
{
    public GameObject prefabPiece;
    public GameObject prefabBillet;
    public CurrencySO scriptableObject;
    // Start is called before the first frame update
    void Start()
    {
        newCurrency(scriptableObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void newCurrency(CurrencySO so)
    {
        GameObject prefab;
        switch (so.type)
        {
            case CurrencySO.CurrencyType.Piece:
                prefab = prefabPiece;
                break;
            case CurrencySO.CurrencyType.Billet:
                prefab = prefabBillet;
                break;
        }

        GameObject newCurrency = Instantiate(prefabPiece, Vector3.zero, Quaternion.identity);
        newCurrency.transform.localScale = new Vector3(so.taille, so.taille, newCurrency.transform.localScale.z);
    }

}
