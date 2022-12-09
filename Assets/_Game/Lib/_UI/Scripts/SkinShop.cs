using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : UICanvas
{
   [SerializeField] List<GameObject> ListShopItem;
   public static ESkinType selectType;
   public Text moneyTxt;

   public Button MoneyBtn;
    public Button SelectButton;
    public Button EquippedBtn;
   
    private void Start() {
        UpdateSelect((int) ESkinType.Hat);
    }

    
    public void CloseBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlayUI>();
        Close();
    }
    public void HatBtn()
    {
        selectType = ESkinType.Hat;
        UpdateSelect((int) ESkinType.Hat);
        PresentSkin.Instance.currentType = ESkinType.Hat;
        
    }

     public void PantBtn()
    {
        selectType = ESkinType.Pant;
        UpdateSelect((int) ESkinType.Pant);
        PresentSkin.Instance.currentType =  ESkinType.Pant;
    }

    public void ShieldBtn()
    {
        selectType = ESkinType.Shield;
        UpdateSelect((int) ESkinType.Shield);
        PresentSkin.Instance.currentType =  ESkinType.Shield;
    }

     public void SetBtn()
    {
        selectType = ESkinType.Skin;
        UpdateSelect((int) ESkinType.Skin);
        PresentSkin.Instance.currentType =  ESkinType.Skin;
    }

    public void SelectBtn()
    {
        // PresentSkin.Instance.SpawnItem();
        PresentSkin.Instance.SelectItem();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        Close();
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
