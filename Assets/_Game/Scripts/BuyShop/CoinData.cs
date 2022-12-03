using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinData
{
    public int coin;
    public CoinData(int value)
    {
        coin= value;
    }
    public int GetCoin()
    {
        Debug.Log("Get coin: "+ coin);
        return coin;
    }
    public void SetCoint(int value)
    {
        coin = value;
        Debug.Log("Set coin: "+ coin);
    }
    public void AddCoin(int value)
    {
        coin+=value;
        Debug.Log("Add coin: "+ coin);
    }

    public void SubCoin(int cost)
    {
        coin-=cost;
        Debug.Log("Sub coin: "+ coin);
    }

    public bool IsEnoughMoney(int cost)
    {
         Debug.Log("Enough: coin: "+ coin +" cost: "+ cost);
        return coin>= cost;
    }
}
