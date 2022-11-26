using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private void Awake() 
    {
        DataPlayerController.InitData();
    }
  
}
