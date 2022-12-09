using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : UICanvas
{
    [SerializeField] GameObject selectBtn;
    [SerializeField] Text MoneyTxt;

    private void Update()
    {
        
    }
    
    public void SelectBtn() // Nut chon
    {
        Present.Instance.SelectItem();
        // Present.Instance.UpdateBtn();
    
        // Present.Instance.Equipped.gameObject.SetActive(true);
    }
    public void MoneyBtn()
    {
        Present.Instance.MoneyItem();
    }

    public void UnClockBtn()
    {
        Present.Instance.UnClock();
    }
    public void CloseBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        Close();
    }
    public void EquippedBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        Close();
    }

    

}
