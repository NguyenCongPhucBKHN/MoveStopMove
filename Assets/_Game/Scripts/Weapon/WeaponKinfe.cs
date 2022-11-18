using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponKinfe : Weapon
{
    public override void Attack()
    {
        eWeaponType = character.currentWeaponType;
        bulletPrefab = weaponDatas.GetBulletPrefab(eWeaponType);
        Bullet[] bullets = new Bullet[3];
        for(int i =0; i<bullets.Length;i++)
        {
            bullets[i]= Instantiate(bulletPrefab, TF.position + new Vector3((i-1)*1, 0, (i-1)*1), TF.rotation*Quaternion.Euler(0f, (i-1)*40f, 0f) );
            bullets[i].character= character;
            bullets[i].Move(character.dirAttact + new Vector3(0, 0, (i-1)*20));
        }
        isActivate= (!bullets[0].IsDead && !bullets[1].IsDead && !bullets[2].IsDead);
    }
}
