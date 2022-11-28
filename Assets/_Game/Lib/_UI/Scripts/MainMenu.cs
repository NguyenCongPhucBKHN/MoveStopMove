using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : UICanvas
{
    public Text level;
    private void Update()
    {
        level.text= "Level: "+ Data.Instance.GetLevel().ToString();
    }
    public void PlayButton()
    {
        // UIManager.Instance.OpenUI<GamePlay>();

        LevelManager.Instance.OnStart();
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlayUI>();
        // DataPlayerController.InitData();
        Close();
    }
}
