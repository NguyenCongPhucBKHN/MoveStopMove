using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRepository 
{   
    public DataRepository(int number, ItemModel item)
    {
        maxItem = number;
        // currentItem = item;
        indexItem = item.indexItem;
        indexType = item.indexType;

      
    }
    #region variable & propoty
    public List<int> listItems = new List<int>();
    public int maxItem ; //TODO: Set for each sub class
    public ItemModel currentItem ; //khong save duoc
    public int indexType ;
    public int indexItem ;
    

 
    #endregion

    //Bien tam
    

    #region  logic: check, add, getprev, getnext
    public bool IsOwnedWithId(int idTyp, int idIte)
    {
        return listItems.Contains(idTyp*10+idIte);
    }

    public bool IsOwnedType(int idType)
    {
        for(int i =0; i< listItems.Count; i++)
        {
            int iType = listItems[i]/10;
            Debug.Log("iType: "+ iType+ " "+ idType);
            if(iType == idType) 
            {
                return true;
            }
        }
        return false;
    }

    public bool IsOwnedPrevType(int idType)
    {
        return IsOwnedType(idType-1);
    }

    public void AddItem(int idType, int idItem)
    {   
        if(IsOwnedWithId( idType,  idItem)) 
        {
            return;
        }
       
        listItems.Add(idType*10+idItem);
    }

    public void SetCurrentItem(int idType, int idItem)
    {
        this.indexType = idType;
        this.indexItem = idItem;
        this.currentItem= new ItemModel(idType, idItem);
    }

    public void SetTypeCurrItem(int idType)
    {
        indexType = idType;
    }

    public void SetIndexCurrItem(int idItem)
    {
        indexType = idItem;
    }

    public ItemModel GetCurrentItem()
    {
        return new ItemModel(indexType, indexItem);
    }

    public int GetTypeCurrItem()
    {
        return indexType;
    }

    public int GetIndexCurrItem()
    {
        return indexItem;
    }

    public ItemModel GetPrevItemId()
    {
        ItemModel vitem =new ItemModel(indexType, indexItem);  //TODO: CHECK 0 or 1

        int currentIndex = listItems.IndexOf(indexType*10+  indexItem);
        if(currentIndex > 0)
        {
            int numberItem = listItems[currentIndex-1]; 
            int idType = numberItem%10;
            int idItem = numberItem - idType*10;
            vitem = new ItemModel(idType, idItem);
            
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
         ItemModel vitem =new ItemModel(indexType, indexItem);  //TODO: CHECK 0 or 1

        int currentIndex = listItems.IndexOf(indexType*10+  indexItem);
        if(currentIndex < maxItem-1 )
        {
            int numberItem = listItems[currentIndex+1]; 
            int idType = numberItem%10;
            int idItem = numberItem - idType*10;
            vitem = new ItemModel(idType, idItem);
            
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
