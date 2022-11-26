using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel 
{
    private int indexType;
    private int indexItem;
    ItemModel item;
    public ItemModel()
    {

    }
    public ItemModel(int indexType, int indexItem)
    {
        this.indexType = indexType;
        this.indexItem = indexItem;
    }

    public int IndexType 
    { 
        get { return indexType; }
        set { indexType = value; }
    }

    public int IndexItem
    {
        get { return indexItem; }
        set { indexItem = value; }
    }

    void Start()
    {
        item = new ItemModel(3, 4);

    }
   
    

}
