using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSkin : Singleton<PresentSkin>
{
    
    public ESkinType currentType;
    public int currentIndex ;
    public GenSkin currentSkin;
    public GenSkin[] listGenSkin = new GenSkin[4];
    private void Start() {
        currentType = ESkinType.Hat;
       
    }
    public void SpawnItem()
    {
        currentSkin.SpawnSkin(currentType, currentIndex);
    }

    public void SelectItem()
    {
        if(!DataPlayerController.IsOwnedSkin((int)currentType, currentIndex))
        {
            DataPlayerController.AddSkin((int)currentType, currentIndex);
            DataPlayerController.SetCurrentSkin((int)currentType, currentIndex);
            
        }
        SpawnSaveItem();
    }

    public void SpawnSaveItem()
    {
        for(int i =0; i <4; i++)
        {
            ItemModel item = DataPlayerController.GetCurrentSkin(i);
            listGenSkin[i]?.SpawnSkin((ESkinType)item.indexType, item.indexItem);
        }
    }

}
