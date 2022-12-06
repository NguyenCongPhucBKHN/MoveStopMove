using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Level[] levels;
    public Level currentLevel;

    public Player player;
    
    private void Start() 
    {
        Data.Instance.SetLevel(1);
        LoadLevel(Data.Instance.GetLevel());
    }

    public void OnStart()
   {
        // currentLevel.OnStart();
        player.gameObject.SetActive(true);
        GameManagerr.Instance.currentState = EGameState.GamePlay;
   }

   public void OnFinish()
   { 
        

        GameManagerr.Instance.ChangeState(EGameState.Finish);
        if(currentLevel.isWin)
        {
            UIManager.Instance.OpenUI<Win>();
        }
        else
        {
            UIManager.Instance.OpenUI<Lose>();
        }  
        
        currentLevel.Despawn();
   }

    public void LoadLevel(int index)
    {
        
        if(currentLevel !=levels[index-1] &&  currentLevel != null)
        {
            currentLevel.Despawn();
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levels[index-1]);
        if(currentLevel!= null)
        {  
            player.gameObject.SetActive(true);
            currentLevel.OnInit();
            
        }
        Data.Instance.SetLevel(index);
    }

   

   
   
}
