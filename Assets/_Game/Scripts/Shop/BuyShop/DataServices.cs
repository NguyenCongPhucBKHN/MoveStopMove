using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataServices 
{
    public DataRepository dataRepository;
    private string KEY_DATA;
    private int maxItem;
    private ItemModel initItem;
    public DataServices(string KEY, int maxitem, ItemModel init)
    {
        KEY_DATA= KEY;
        maxItem= maxitem;
        initItem = new ItemModel(init.IndexType, init.IndexItem);
    }
    public void InitDataServices()
    {
        dataRepository = JsonUtility.FromJson<DataRepository>(PlayerPrefs.GetString(KEY_DATA));
        Debug.Log("dataRepository: "+ dataRepository);

        if(dataRepository==null)
        {
            dataRepository = new DataRepository(maxItem, initItem);
            Debug.Log("MAX_ITEM: "+ dataRepository.MAX_ITEM);
            Debug.Log("vItem.IndexItem: "+ initItem.IndexItem);
            dataRepository.SetCurrentItem(initItem.IndexType, initItem.IndexType);
            dataRepository.AddItem(initItem.IndexType, initItem.IndexType);
        }
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(dataRepository);
        PlayerPrefs.SetString(KEY_DATA, data);
    }

    public bool IsOwnedItem(int type, int index)
    {
        return dataRepository.IsOwnedWithId(type, index);
    }

    public void AddItem(int type, int index)
    {
        dataRepository.AddItem(type, index);
        SaveData();
    }

    public void SetCurrentItem(int type, int index)
    {
        dataRepository.SetCurrentItem(type, index);
        SaveData();
    }

    public ItemModel GetCurrentItem()
    {
        return dataRepository.GetCurrentItem();
    }
    public ItemModel GetPrevItem()
    {
        ItemModel current = dataRepository.GetPrevItemId();
        SaveData();
        return current;
    }

    public ItemModel GetNextItem()
    {
        ItemModel current = dataRepository.GetNextItemId();
        SaveData();
        return current;
    }




}
