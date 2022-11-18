using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    [SerializeField] private Transform BoomerangImgTF;
    bool isHit= false;

    public override void OnInit()
    {
        speedBullet= 10;
    }
    private void Update()
    {
        BoomerangImgTF.Rotate(0, 0, 10, Space.Self);

        if(isHit)
        {
            float speed= speedBullet*Time.deltaTime;
            TF.position= Vector3.MoveTowards(TF.position, character.weaponGenTF.position, speed);
        }

        if(isHit && Vector3.Distance(TF.position, character.weaponGenTF.position)<0.01)
        {
            IsDead= true;
            Destroy(this.gameObject);
        }
        
        
    }
    public override void OnDespawn()
    {
        isHit=true;
    }
}
