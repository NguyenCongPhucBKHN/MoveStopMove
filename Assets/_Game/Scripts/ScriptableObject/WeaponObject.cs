using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    public EWeaponType weaponType;
    public Transform TF;
    public WeaponDatas weaponDatas;
    public void GetWeaponPrefab(EWeaponType eWeaponType)
    {
        weaponDatas.GetWeaponPrefab(eWeaponType);
    }
}
