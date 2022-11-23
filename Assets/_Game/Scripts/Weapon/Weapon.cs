using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform TF;
    protected EWeaponType eWeaponType;
    [SerializeField]
    protected Bullet bulletPrefab;
    [SerializeField] public WeaponDatas weaponDatas;
    [SerializeField] public Vector3 offsetRotation;
    [SerializeField] private MeshRenderer meshRenderer;
    public WeaponDataa weaponDataa;
    public Character character;
    protected bool isActivate = true;
   
    void Start()
    {
        OnInit();
        InitData();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }
    void  OnInit()
    {
        
        
    }
    void InitData()
    {
        // eWeaponType =(EWeaponType) Random.Range(0, Constant.NUMBER_WEAPONS);
        eWeaponType = character.currentWeaponType;
        int numberMaterial = weaponDataa.listWeaponMaterials.GetWeaponMaterialDatas(eWeaponType).numberMaterial;
        int idrandom = Random.Range(0, numberMaterial);
        weaponDataa?.SetEWeaponType((int)eWeaponType);
        weaponDataa?.SetIndexMaterial(idrandom);
        weaponDataa?.SetMaterial();
        meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
    }
    
    public virtual void Attack()

    {   
            
            // character.weapon.gameObject.SetActive(false);
            // eWeaponType = character.currentWeaponType;
            bulletPrefab = weaponDatas.GetBulletPrefab(eWeaponType);
            character.dirAttact.y=0;
            Bullet bullet = Instantiate(bulletPrefab, TF.position,Quaternion.identity);
            bullet.meshRenderer.materials = weaponDataa.GetMaterial().ToArray();
            // bullet.TF.localScale = character.TF.localScale;
            bullet.TF.localScale= character.TF.localScale;
            bullet.character= character;
            bullet.Move(character.dirAttact);
            isActivate = !bullet.IsDead;
    }
    
}
