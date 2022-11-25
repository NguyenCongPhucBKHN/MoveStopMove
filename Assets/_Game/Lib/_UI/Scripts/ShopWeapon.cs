using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeapon : UICanvas
{
    [SerializeField] GameObject selectBtn;
    public void SelectBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlayUI>();
        Close();
    }

    public void CloseBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlayUI>();
        Close();
    }

}
