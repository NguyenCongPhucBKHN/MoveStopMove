using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponElement : Item
{
    public MeshRenderer meshRenderer;
    public int index;
    public Present present;
    public Button purchaseBtn;
    private Player player;
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void OnClick()
    {
        present.indexSelect = index; //indexMaterial
        present.UpdateSelect();
        // Debug.Log("present.currentWeaponType: "+ present.currentWeaponType);
        // player.currentWeaponType = (EWeaponType) present.currentWeaponType; 
        player.weapon.OnDespawn();
        player.weapon.InitData(present.indexSelect);
    }
    
    
}
