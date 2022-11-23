using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MoveStopMove/ListWeaponMaterials")]
public class ListWeaponMaterials : ScriptableObject
{
    [SerializeField] List<WeaponMaterialDatas> listWeaponMaterialDatas;
    public Material GetMaterial(int index, EWeaponType weaponType)
    {
        for(int i =0; i<listWeaponMaterialDatas.Count; i++)
        {
            if((int)weaponType == i)
            {
               return  listWeaponMaterialDatas[i].GetMaterial(index);
            }
        }
        return null;
    }
}

