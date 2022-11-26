using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRepository 
{   
    public DataRepository(int number, ItemModel item)
    {
        MAX_ITEM = number;
        currentItem = item;
    }
    #region variable & Pro
    public List<ItemModel> listItems = new List<ItemModel>();
    private int maxItem=9 ; //TODO: Set for each sub class
    private ItemModel currentItem;
    public ItemModel CurrentItem 
    { 
        get { return currentItem; }
        set { currentItem = value; }
    }

    public int MAX_ITEM 
    {
        get { return maxItem; }
        set { maxItem = value; }
    }
    #endregion

    //Bien tam
    

    #region  logic: check, add, getprev, getnext
    public bool IsOwnedWithId(int idTyp, int idIte)
    {
        for (int i =0; i < listItems?.Count; i++)
        {
            if(listItems[i].IndexType == idTyp && listItems[i].IndexItem == idIte)
            {
                return true;
            }
        }
        return false; 
    }

    public void AddItem(int idType, int idItem)
    {   
        if(IsOwnedWithId( idType,  idItem)) 
        {
            return;
        }
        ItemModel vitem = new ItemModel(idType, idItem);
        listItems.Add(vitem);
        Debug.Log("listItems222: "+ listItems.Count);
    }

    public void SetCurrentItem(int idType, int idItem)
    {
        
        this.currentItem= new ItemModel(idType, idItem);
    }

    public void SetTypeCurrItem(int idType)
    {
        currentItem.IndexType = idType;
    }

    public void SetIndexCurrItem(int idItem)
    {
        currentItem.IndexType = idItem;
    }

    public ItemModel GetCurrentItem()
    {
        return currentItem;
    }

    public int GetTypeCurrItem()
    {
        return currentItem.IndexType;
    }

    public int GetIndexCurrItem()
    {
        return currentItem.IndexItem;
    }

    public ItemModel GetPrevItemId()
    {
        ItemModel vitem = new ItemModel(0, 0); //TODO: CHECK 0 or 1

        int currentIndex = listItems.IndexOf(currentItem);
        if(currentIndex > 0)
        {
            vitem = listItems[currentIndex-1];
            
        }
        else
        {
           // vitem = listItems[listItems.Count-1];
        }
        currentItem = vitem;
        return vitem;
    }

    public ItemModel GetNextItemId()
    {
        ItemModel vitem = new ItemModel(0, 0); //TODO: CHECK 0 or 1
        int currentIndex = listItems.IndexOf(currentItem);
        if(currentIndex < maxItem-1 )
        {
            vitem = listItems[currentIndex+1];
            
        }
        else
        {
           // vitem = listItems[listItems.Count-1];
        }
        currentItem = vitem;
        return vitem;
    }
    #endregion
}
