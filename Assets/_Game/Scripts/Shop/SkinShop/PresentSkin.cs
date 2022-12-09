using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentSkin : Singleton<PresentSkin>
{
    public GameObject MoneyBtn;
    public GameObject SelectBtn;
    public GameObject EquippedBtn;
    
    public ESkinType currentType;
    public int currentIndex ;
    public GenSkin currentSkin ;
    public bool isCurrent, isOwned, noHave;
    public GenSkin[] listGenSkin = new GenSkin[4];
    private void Start() {
        currentType = ESkinType.Hat;
       
    }
    public void SpawnItem()
    {
        currentSkin.SpawnSkin(currentType, currentIndex);
    }

    public void MoneyItem() //Button money
    {
        int cost = (int)currentType+1 *100 + currentIndex*10;
        if(DataPlayerController.IsEnoughMoney(cost))
        {
            DataPlayerController.SubCoin(cost);
            DataPlayerController.AddSkin((int)currentType, currentIndex);
        }
    }

    public void SelectItem() //Button select/equip
    {
        // if(!DataPlayerController.IsOwnedSkin((int)currentType, currentIndex))
        // {
            DataPlayerController.AddSkin((int)currentType, currentIndex);
        // }
        // DataPlayerController.SetCurrentSkin((int)currentType, currentIndex);
        // SpawnSaveItem();
    }



    public void SpawnSaveItem()
    {
        for(int i =0; i <4; i++)
        {
            ItemModel item = DataPlayerController.GetCurrentSkin(i);
            listGenSkin[i]?.SpawnSkin((ESkinType)item.indexType, item.indexItem);
        }
    }

    public bool isUsed(int itype, int index)
    {
        ItemModel item = DataPlayerController.GetCurrentSkin(itype);
        return item.indexItem == index;
    }

    public void ActivateBtn(int num)
    {
        int first = num%100;
        int second = (num- first *100)%10;
        int last = num -first*100- second*10;
        isCurrent= ConvertIntToBool(last);
        isOwned= ConvertIntToBool(second);
        noHave= ConvertIntToBool(first);
    }

    bool ConvertIntToBool(int i)
    {
        return i!=0;
    }

    public int GetCostItem()
    {
        return ((int)currentType+1) *100 + currentIndex*10;
    }
}
