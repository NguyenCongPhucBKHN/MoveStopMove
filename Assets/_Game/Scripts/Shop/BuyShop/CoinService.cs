using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinService 
{
    public CoinData coinData;
    public int initCoin;
    private string KEY_DATA;
    public CoinService(string KEY, int coin)
    {
        KEY_DATA= KEY;
        initCoin = coin;
    }

    public void InitDataService()
    {
        coinData = JsonUtility.FromJson<CoinData>(PlayerPrefs.GetString(KEY_DATA));
        if(coinData==null)
        {
            coinData = new CoinData(initCoin);
        }
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(coinData);
        PlayerPrefs.SetString(KEY_DATA, data);
    }

    public int GetCoin()
    {
        return coinData.GetCoin();
    }
    public void AddCoin(int value)
    {
        coinData.AddCoin(value);
        SaveData();
    }
    public void SubCoin(int cost)
    {
        coinData.SubCoin(cost);
        SaveData();
    }
    public bool IsEnoughMoney(int cost)
    {
        return coinData.IsEnoughMoney(cost);
    }
}
