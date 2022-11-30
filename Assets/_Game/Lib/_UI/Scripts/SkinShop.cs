using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : UICanvas
{
    
   [SerializeField] List<GameObject> ListShopItem;
   
   
    private void Start() {
        // UIManager.Instance.OpenUI<HatShop>();
        UpdateSelect(0);
    }
    public void HatBtn()
    {
        // UIManager.Instance.OpenUI<HatShop>();
        UpdateSelect(0);
        
    }

     public void PantBtn()
    {
        // UIManager.Instance.OpenUI<PantShop>();
        UpdateSelect(1);
    }

    public void ShieldBtn()
    {
        // UIManager.Instance.OpenUI<ShieldShop>();
        UpdateSelect(2);
    }

     public void SetBtn()
    {
        // UIManager.Instance.OpenUI<SetShop>();
        UpdateSelect(3);
    }

    void UpdateSelect(int j)
    {
        for(int i =0; i<ListShopItem.Count; i++)
        {
            if(i == j)
            {
                ListShopItem[i].SetActive(true);
            }
            else
            {
                ListShopItem[i].SetActive(false);
            }
        }
    }
    
}
