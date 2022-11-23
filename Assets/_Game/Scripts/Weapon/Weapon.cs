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
   
    public Character character;
    protected bool isActivate = true;
   
    void Start()
    {
        // OnInit();
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
        // eWeaponType =(EWeaponType) Random.Range(0, 3);
    }
    
    public virtual void Attack()

    {   
            // character.weapon.gameObject.SetActive(false);
            eWeaponType = character.currentWeaponType;
            bulletPrefab = weaponDatas.GetBulletPrefab(eWeaponType);
            character.dirAttact.y=0;
            Debug.Log("character.weaponGenTF.rotation: "+ character.weaponGenTF.rotation);
            Bullet bullet = Instantiate(bulletPrefab, TF.position,Quaternion.identity);
            // bullet.TF.localScale = character.TF.localScale;
            Debug.Log("character scale: "+ character.TF.localScale);
             bullet.TF.localScale= character.TF.localScale;
            Debug.Log("bullet rotation: "+ bullet.transform.rotation);
            bullet.character= character;
            bullet.Move(character.dirAttact);
            isActivate = !bullet.IsDead;
    }
    
}
