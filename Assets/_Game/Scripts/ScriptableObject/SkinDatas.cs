using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MoveStopMove/SkinDatas")]
public class SkinDatas : ScriptableObject
{
    [SerializeField] List<SkinDataObject> listDatas;

    public GameObject GetPrefab(int indexType, int indexIndex)
    {
        for(int i =0; i<listDatas.Count; i++)
        {
            if(listDatas[i].intType == indexIndex && listDatas[i].indexItem == indexIndex)
            {
                return listDatas[i].prefab;
            }
        }
        return null;
    }
    

}
