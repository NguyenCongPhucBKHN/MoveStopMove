using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "MoveStopMove/BodyMaterialDatas")]
public class BodyMaterialDatas : ScriptableObject
{
    [SerializeField] List<BodyMaterialData> bodyMaterialDatas;

    public Material GetMaterial(EBodyMaterialType eBodyMaterialType)
    {
        for(int i =0; i< bodyMaterialDatas.Count; i++)
        {
            if(bodyMaterialDatas[i].bodyType == eBodyMaterialType)
            {
                return bodyMaterialDatas[i].material;
            }
        }
        return null;
    }

    // public EBodyMaterialType GetEBodyMaterialType(Material material)
    // {
    //     for(int i =0; i< bodyMaterialDatas.Count; i++)
    //     {
    //         if(bodyMaterialDatas[i].material== material)
    //         {
    //             return bodyMaterialDatas[i].bodyType;
    //         }
    //     }
       
    // }
    
}
