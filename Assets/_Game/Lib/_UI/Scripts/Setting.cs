using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public void ContinueButton()
    {
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlayUI>();
        Close();
    }

    public void ReLoadLevel()
    {
        UIManager.Instance.OpenUI<MainMenu>();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        LevelManager.Instance.LoadLevel(Data.Instance.GetLevel());
        Close();
    }

    public void RePlayButton()
    {
        UIManager.Instance.OpenUI<MainMenu>();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        Data.Instance.SetLevel(1);
        LevelManager.Instance.LoadLevel(1);
        Close();

    }

}
