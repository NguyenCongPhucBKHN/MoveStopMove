using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : GameUnit
{
    protected EWeaponType eWeaponType;
    [SerializeField]
    protected Bullet bulletPrefab;
    [SerializeField] public WeaponDatas weaponDatas;
    [SerializeField] public Vector3 offsetRotation;
    [SerializeField] private MeshRenderer meshRenderer;
    public WeaponDataa weaponDataa;
    public Character character;
    protected bool isActivate = true;
    public int indexMat ;
   
    void Start()
    {
        indexMat = Random.Range(0,3);
        // OnInit();
    }
    
  
    // void  OnInit()
    // {
        
        
    // }
    public void InitData(int eType,int indexMaterial) 
    {
        this.indexMat = indexMaterial;
        if(character!=null)
        {
            eWeaponType =  character.currentWeaponType;
            weaponDataa?.SetEWeaponType((int)eWeaponType);
            weaponDataa?.SetMaterial( this.indexMat);
            meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
        }
        else
        {
            eWeaponType =(EWeaponType) eType;
            weaponDataa?.SetEWeaponType((int)eWeaponType);
            weaponDataa?.SetMaterial( this.indexMat);
            meshRenderer.materials= weaponDataa.GetMaterial().ToArray();
        }
        
    }
    
    public virtual void Attack()

    {   
            bulletPrefab = weaponDatas.GetBulletPrefab(eWeaponType);
            character.dirAttact.y=0;
            Bullet bullet = SimplePool.Spawn<Bullet>(bulletPrefab, tf.position,Quaternion.identity);
            bullet.meshRenderer.materials = weaponDataa.GetMaterial().ToArray();
            bullet.TF.localScale= character.TF.localScale;
            bullet.character= character;
            bullet.Move(character.dirAttact);
            isActivate = !bullet.IsDead;
    }

    public void OnDespawn()
    {
        Destroy(this.gameObject);
        // if(this.eWeaponType!= character.currentWeaponType)
        // {
        //     Destroy(this.gameObject);
        //     // this.gameObject.SetActive(false);
        //     character.SpawnWeapon();
        // }
        // else
        // {
        //     Destroy(this.gameObject);
        // }
    }
    
}
