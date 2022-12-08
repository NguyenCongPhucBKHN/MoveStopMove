using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : UICanvas
{
    [SerializeField] GameObject selectBtn;
    [SerializeField] Text MoneyTxt;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        
    }
    
    public void SelectBtn()
    {
        Present.Instance.SelectItem();
        Present.Instance.Equipped.gameObject.SetActive(true);
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
