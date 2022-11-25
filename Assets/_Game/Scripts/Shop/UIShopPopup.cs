using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopPopup : MonoBehaviour
{
    public Button hideBtn; // Hide shop btn
    public UIShopElement[] shopElements;

    void Awake()
    {
        // hideBtn.onClick.AddListener(OnHideShop);
        SetData();
    }
    private void  OnValidate()
    {
        if(shopElements==null || shopElements.Length ==0)
        {
            shopElements = GetComponentsInChildren<UIShopElement>();
        }
    }

    private void SetData()
    {
        for( int i = 0; i <shopElements.Length; i++ )
        {
            shopElements[i].SetData(i+1);
        }
    }
    public void OnHideShop()
    {

    }
}
