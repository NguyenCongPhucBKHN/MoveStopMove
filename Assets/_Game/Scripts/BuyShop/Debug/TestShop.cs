using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SkinDataModel dataModel = new SkinDataModel();
        dataModel.indexType =1;
        dataModel.indexItem =2;
        Debug.Log("Skin data string: "+ dataModel.ConvertToString());
        SkinDataModel model2= SkinDataModel.ConverToModel(dataModel);
        Debug.Log("data2: item: "+ model2.indexType+ " "+ model2.indexItem);
    }

    

    void DebugCurrentWeapon()
    {
        ItemModel item = DataPlayerController.GetCurrentWeapon();
        Debug.Log("test: " + item);
    }
}
