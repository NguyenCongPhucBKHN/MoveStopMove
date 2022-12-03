using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeapon : UICanvas
{
    [SerializeField] GameObject selectBtn;
    
    public void SelectBtn()
    {
        Present.Instance.SelectItem();
        // GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        // UIManager.Instance.OpenUI<GamePlayUI>();
        // Close();
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
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlayUI>();
        Close();
    }

}
