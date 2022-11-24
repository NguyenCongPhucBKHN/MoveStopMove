using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MoveStopMove/PresentWeapons")]
public class PresentWeapons : ScriptableObject
{
    public List<PresentWeapon> listDataWeapons ;

    public int GetIndexTypeWeapon(PresentWeapon weapon)
    {
        return weapon.indexTypeWeapon;
    }

    public ShopHammerElement GetPrefabWeapon(int index)
    {
        for(int i =0; i< listDataWeapons.Count; i++)
        {
            if(listDataWeapons[i].indexTypeWeapon == index)
            {
                return listDataWeapons[i].weaponprefab;
            }
        }
        return null;
    }
    public int GetCountWeapon()
    {
        return listDataWeapons.Count;
    }

}
