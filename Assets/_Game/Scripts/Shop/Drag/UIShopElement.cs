using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
    public int id;
    public int cost;
    public Text costTxt;
    public Button purchaseBtn;
    
    
    void Awake()
    {
        
    }
    public void SetData(int id)
    {
        this.id= id;
        cost = id*100;
        UpdateView();
    }

    private void UpdateView()
    {
        // Kiem tra co dang so huu khong
        bool isOwned =DataPlayer.IsOwnedWithId(id);

        if(isOwned) //Neu so huu thi khong cho mua
        {
            purchaseBtn.enabled= false;
            costTxt.text = "Owned";
        }
        else
        {
            purchaseBtn.enabled = true;
            costTxt.text = cost.ToString();
        }
    }

    private void OnPurchase() // An vao button mua
    {
        bool canPurchase =DataPlayer.IsEnoughMoney(cost);
        if(canPurchase)
        {
           DataPlayer.AddItem(id);
            UpdateView();
           DataPlayer.SubCoin(cost);
        }
    }

}
