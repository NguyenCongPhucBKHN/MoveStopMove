using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class DataPlayer  //static: Coi nhu 1 Instance
{
    private static AllData allData;
    private const string ALL_DATA = "all_data";
    private static UnityEvent updateCoinEvent = new UnityEvent();
   static DataPlayer()
   {
    //Chuyen doi du lieu sang kieu AllData;
    allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));

    if(allData ==null)
    {
        int itemDefault =1;
        allData = new AllData
        {
            listItems = new List<int>{itemDefault},
            currentItem = itemDefault,
            coin =1000,
        };
        SaveData();
    }
   }
   private static void SaveData()
   {
        string data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
   }

    public static bool IsOwnedWithId(int id)
    {
        return allData.IsOwnedWithId(id);
    }

    public static void AddItem(int id)
    {
        allData.AddItem(id);
        SaveData();
    }
    public static void SetCurrentItem(int item)
    {
        allData.SetCurrentItem(item);
    }

    public static int GetCurrentItem()
    {
        return allData.GetCurrentItem();
    }

    public static int GetPrevItem()
    {
        int currentIndex = allData.GetPrevItemId();
        SaveData();
        return currentIndex;
    }

    public static int GetNextItem()
    {
        int currentIndex = allData.GetNextItemId();
        SaveData();
        return currentIndex;
    }
    public static bool IsEnoughMoney(int cost)
    {
        return allData.IsEnoughMoney(cost);
    }
    public static int GetCoin()
    {
        return allData.GetCoin();
    }
    public static void AddCoin(int value)
    {
        allData.AddCoin(value);
        updateCoinEvent.Invoke();
        SaveData();
    }

    public static void SubCoin(int cost)
    {
        allData.SubCoin(cost);
        updateCoinEvent.Invoke();
        SaveData();
    }
    //Lang nghe su kien cap nhat coin
    public static void AddListener(UnityAction updateCoin)
    {
        updateCoinEvent.AddListener(updateCoin);
    }

    public static void RemoveListener(UnityAction updateCoin)
    {
        updateCoinEvent.RemoveListener(updateCoin);
    }
}
   


