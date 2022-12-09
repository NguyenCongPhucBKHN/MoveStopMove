using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        LevelManager.Instance.OnStart();
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        DataPlayerController.coinInLevel =0;
        UIManager.Instance.OpenUI<GamePlayUI>();
        Close();
    }
    public void WeaponBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.Pause);
        UIManager.Instance.OpenUI<ShopWeapon>();
        Close();
    }
    public void SkinBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.Pause);
        UIManager.Instance.OpenUI<SkinShop>();
        Close();
    }

}
