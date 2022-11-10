using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform TF;
    [SerializeField] EBulletType bulletType;
    [SerializeField] Bullet bulletPrefab;
    public Character character;

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.A))
    //     {
    //         Attack();
    //     }
    // }
    
    public void Attack()
    {
        Bullet bullet = Instantiate(bulletPrefab, TF.position, TF.rotation);
        bullet.character= character;

    
    }
    
}
