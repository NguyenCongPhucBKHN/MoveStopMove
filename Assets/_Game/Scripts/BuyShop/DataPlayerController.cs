using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPlayerController 
{
    //Key
    private static string KEY_WEAPON = "weapon";
    private static string KEY_HAT ="Skin";
    private static string KEY_PANT ="pant";
    private static string KEY_SHIELD = "shield";
    private static string KEY_SKIN ="skin";
    private static string KEY_COIN ="Coin";
    
    public static int initCoin=100;
    public static ItemModel weaponInit = new ItemModel(0, 0);
    public static ItemModel hatInit =new ItemModel(0, -1);
    public static ItemModel pantInit =new ItemModel(1, -1);
    public static ItemModel shieldInit =new ItemModel(2, -1);
    public static ItemModel skinInit =new ItemModel(3, -1);
    public static int MAX_WEAPON =5;
    public static int MAX_SKIN =5;

    private static CoinService coinData=  new CoinService(KEY_COIN, initCoin);
    private static DataServices weaponData = new DataServices(KEY_WEAPON, weaponInit, MAX_WEAPON );
    private static DataServices hatData = new DataServices(KEY_HAT, hatInit);
    private static DataServices pantData = new DataServices(KEY_PANT, pantInit);
    private static DataServices shieldData = new DataServices(KEY_SHIELD, shieldInit);
     private static DataServices shinData = new DataServices(KEY_SKIN, skinInit);
    private static List<DataServices> Listskin = new List<DataServices>{hatData,pantData,shieldData, shinData  };

    // public static void InitData()
    // {
    //     weaponData?.InitDataServices();
    //     hatData?.InitDataServices();
    //     Debug.Log("skindata: "+ JsonUtility.ToJson(hatData));
    //     coinData?.InitDataService();
    // }

    public static void SaveData()
    {
        weaponData.SaveData();
        hatData.SaveData();
        pantData.SaveData();
        shieldData.SaveData();
        shinData.SaveData();
        coinData.SaveData();
    }

    public static bool IsOwnedWeapon(int type, int index)
    {
        return weaponData.IsOwnedItem(type, index);
    }
    

    
    





    public static bool IsOwnedWeaponType(int type)
    {
        return weaponData.IsOwnedType(type);
    }

    public static bool IsOwnedPrevWeaponType(int type)
    {
        return weaponData.IsOwnedPrevType(type);
    }
   

      public static bool IsOwnedPrevWeapon(int type, int index)
    {
        return weaponData.IsOwnedItem(type, index);
    }

    public static void AddWeapon(int type, int index)
    {
        weaponData.AddItem(type, index);
        SaveData();
    }

    

    public static void SetCurrentWeapon(int type, int index)
    {
        weaponData.SetCurrentItem(type, index);
        SaveData(); //TODO CHECKBUG   
    }
    

    public static ItemModel GetCurrentWeapon()
    {
        
        return weaponData.GetCurrentItem();
    }


    public static ItemModel GetPrevWeapon()
    {
        return weaponData.GetPrevItem();
    }

   

    public static ItemModel GetNextWeapon()
    {
        return weaponData.GetNextItem();
    }

    public static bool IsOwnedSkin(int type, int index)
    {
        return Listskin[type].IsOwnedItem(type, index);
    }

    public static void AddSkin(int type, int index)
    {
        Listskin[type].AddItem(type, index);
        SetCurrentSkin(type,index);
        Debug.Log("Listskin[type]"+ JsonUtility.ToJson(Listskin[type]));
        SaveData();
    }

    public static void SetCurrentSkin(int type, int index)
    {
        Listskin[type].SetCurrentItem(type, index);
        SaveData(); //TODO CHECKBUG   
    }
    public static ItemModel GetCurrentSkin(int type)
    {
        return Listskin[type].GetCurrentItem();
    }
    

    // public static bool IsOwnedSkin(int type, int index, int factor)
    // {
    //      return hatData.IsOwnedItem(type, index, 100);
    // }
   

    // public static ItemModel GetItemSkin()
    // {
    //     return hatData.GetCurrentItem();
    // }

    // public static ItemModel GetNextSkin()
    // {
    //     return hatData.GetNextItem();
    // }
    //   public static ItemModel GetPrevSkin()
    // {
    //     return hatData.GetPrevItem();
    // }

    

    public static bool IsEnoughMoney(int cost)
    {
        return coinData.IsEnoughMoney(cost);
    }

    public static void AddCoin(int value)
    {
        coinData.AddCoin(value);
    }

    public static void SubCoin(int cost)
    {
        coinData.AddCoin(cost);
    }

    
}
