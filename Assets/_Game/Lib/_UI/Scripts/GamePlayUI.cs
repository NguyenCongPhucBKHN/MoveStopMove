using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : UICanvas
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    [SerializeField] GameObject settingBtn;
    [SerializeField] Text Alive;
     /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Alive.text = "Alive: "+ LevelManager.Instance.currentLevel.totalAmount;
    }
    public void SettingBtn()
    {
        GameManagerr.Instance.ChangeState(EGameState.Pause);
        UIManager.Instance.OpenUI<Setting>();
        Close();   
    }

}
