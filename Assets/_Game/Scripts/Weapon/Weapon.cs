using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform TF;
     EWeaponType eWeaponType;
    [SerializeField]
    Bullet bulletPrefab;
    [SerializeField] public WeaponDatas weaponDatas;
   
    public Character character;
    bool isActivate = true;
   
    void Start()
    {
        // OnInit();
    }
    void  OnInit()
    {
        // eWeaponType =(EWeaponType) Random.Range(0, 3);
    }
    
    public void Attack()

    {   
            
            eWeaponType = character.currentWeaponType;
            bulletPrefab = weaponDatas.GetBulletPrefab(eWeaponType);

            if(eWeaponType == EWeaponType.Knife)
            {
                Bullet[] bullets = new Bullet[3];
                for(int i =0; i<bullets.Length;i++)
                {
                    bullets[i]= Instantiate(bulletPrefab, TF.position + new Vector3((i-1)*1, 0, (i-1)*1), TF.rotation*Quaternion.Euler(0f, (i-1)*40f, 0f) );
                    bullets[i].character= character;
                    bullets[i].Move(character.dirAttact + new Vector3(0, 0, (i-1)*20));
                }
                isActivate= (!bullets[0].IsDead && !bullets[1].IsDead && !bullets[2].IsDead);
            }
            else
            {
                Bullet bullet = Instantiate(bulletPrefab, TF.position, TF.rotation);
                bullet.character= character;
                bullet.Move(character.dirAttact);
                isActivate = !bullet.IsDead;
            }
            
        

    }
    
}
