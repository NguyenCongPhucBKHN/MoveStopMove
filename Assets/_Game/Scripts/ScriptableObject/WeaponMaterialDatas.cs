using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeaponMaterialDatas 
{
    [SerializeField] List<WeaponMaterialData> weaponMaterialDatas;
     int numberMaterial;
    [SerializeField] EWeaponType weaponType;

    public Material GetMaterial(int index)
    {
        numberMaterial = weaponMaterialDatas.Count;
        for(int i =0; i< numberMaterial; i++)
        {
            if(index ==i) {
                return weaponMaterialDatas[i].material;
                
            }
        }
        return null;
    } 
}


