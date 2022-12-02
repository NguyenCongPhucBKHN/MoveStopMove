using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDataModel
{
    public int indexType;
    public int indexItem;

    public string ConvertToString()
    {
        return JsonUtility.ToJson(this);
    }

    public static SkinDataModel ConverToModel(SkinDataModel skinData)
    {
        return JsonUtility.FromJson<SkinDataModel>(skinData.ConvertToString());
    } 
}
