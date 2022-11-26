using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponElement : Item
{
    public MeshRenderer meshRenderer;
    private int indexMaterial;
    private Player player;

    private EWeaponType eWeaponType;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetIndexMaterial(int id)
    {   
        indexMaterial = id;
    }
    
    public void SetWeaponType(EWeaponType eWeaponType)
    {
        this.eWeaponType = eWeaponType;
    }


    public void OnSelect()
    {
        Present.Instance.indexSelect= indexMaterial; 
        Present.Instance.UpdateSelect();
        if(DataPlayerController.IsOwnedWeapon(0, 0))
        {
            player.currentWeaponType = (EWeaponType) Present.Instance.currentWeaponType;
            Debug.Log("(EWeaponType) present.currentWeaponType: "+ (EWeaponType) Present.Instance.currentWeaponType);
            player.weapon.OnDespawn();
            player.weapon.InitData(Present.Instance.indexSelect);
            Present.Instance.SelectItem();
        }
        ItemModel item = DataPlayerController.GetCurrentWeapon();
        Debug.Log("crrr: "+ item.IndexType + item.IndexItem);
        
        
    }
}
