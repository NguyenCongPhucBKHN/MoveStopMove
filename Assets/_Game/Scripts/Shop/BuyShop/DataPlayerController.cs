using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPlayerController 
{
    //Key
    private static string KEY_WEAPON = "weapon";
    private static string KEY_SKIN ="Skin";
    private static string KEY_COIN ="Coin";

    //Init value
    public static int initCoin=100;
    public static ItemModel weaponInit = new ItemModel(0, 0);
    public static ItemModel skinInit = new ItemModel(0 , 0);

    //
    public static int MAX_WEAPON =9;
    public static int MAX_SKIN =5;

    private static CoinService coinData=  new CoinService(KEY_COIN, initCoin);
    private static DataServices weaponData = new DataServices(KEY_WEAPON, MAX_WEAPON, weaponInit);
    private static DataServices skinData = new DataServices(KEY_SKIN, MAX_SKIN, skinInit);

    public static void InitData()
    {
        weaponData?.InitDataServices();
        skinData?.InitDataServices();
        coinData?.InitDataService();
    }

    public static void SaveData()
    {
        weaponData.SaveData();
        skinData.SaveData();
        coinData.SaveData();
    }

    public static bool IsOwnedWeapon(int type, int index)
    {
        return weaponData.IsOwnedItem(type, index);
    }

    public static bool IsOwnedSkin(int type, int index)
    {
        return skinData.IsOwnedItem(type, index);
    }

    public static void AddWeapon(int type, int index)
    {
        weaponData.AddItem(type, index);
        // SaveData();
    }

    public static void AddSkin(int type, int index)
    {
        skinData.AddItem(type, index);
        // SaveData();
    }

    public static void SetCurrentWeapon(int type, int index)
    {
        weaponData.SetCurrentItem(type, index);
        // SaveData(); //TODO CHECKBUG   
    }
    public static void SetCurrentSkin(int type, int index)
    {
        weaponData.SetCurrentItem(type, index);
        SaveData();
    }

    public static ItemModel GetCurrentWeapon()
    {
        return weaponData.GetCurrentItem();
    }

    public static ItemModel GetItemSkin()
    {
        return skinData.GetCurrentItem();
    }

    public static ItemModel GetPrevWeapon()
    {
        return weaponData.GetPrevItem();
    }

     public static ItemModel GetPrevSkin()
    {
        return skinData.GetPrevItem();
    }

    public static ItemModel GetNextWeapon()
    {
        return weaponData.GetNextItem();
    }

    public static ItemModel GetNextSkin()
    {
        return skinData.GetNextItem();
    }


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
