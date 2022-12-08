using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeaponElement : Item
{
    [SerializeField] protected GameObject ClockObj;
    public MeshRenderer meshRenderer;
    private EWeaponType eWeaponType;
    private int indexMaterial;
    protected bool isOwned ;
    private Player player;

    

    
    void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void Start() 
    {
        ActivateClock();
        Present.Instance.MoneyEven.AddListener(ActivateClock);
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
        Present.Instance.UpdateBtn((int)eWeaponType, (int)indexMaterial);
        Present.Instance.MoneyTxt.text = "Buy with " + Present.Instance.GetCost((int)eWeaponType, (int)indexMaterial);
        // ActivateClock();
        
    }
    public void ActivateClock()
    {
        if(!DataPlayerController.IsOwnedWeapon((int)eWeaponType, indexMaterial))
        {
            ClockObj.SetActive(true);
        }
        else
        {
            ClockObj.SetActive(false);
        }
    }
}
