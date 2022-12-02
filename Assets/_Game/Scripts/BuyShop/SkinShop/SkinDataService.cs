using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDataService
{

    private string KEY_DATA ;
    public DataRepository dataRepository;
    private int maxItem;

    // public SkinDataService(string Key)
    // {
    //     KEY_DATA = Key;
    //     dataRepository = JsonUtility.FromJson<DataRepository>(PlayerPrefs.GetString(KEY_DATA));
    //     if(dataRepository ==null)
    //     {
    //         // dataRepository = new DataRepository();
    //     }
    // }
}
