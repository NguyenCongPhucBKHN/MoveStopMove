using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : UICanvas
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    [SerializeField] GameObject settingBtn;
   
    public void SettingBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.Pause);
        UIManager.Instance.OpenUI<Setting>();
        Present.Instance.UpdateBtn(DataPlayerController.GetCurrentWeapon().indexType,DataPlayerController.GetCurrentWeapon().indexItem );
        Close();   
    }

}
