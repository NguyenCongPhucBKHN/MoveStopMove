using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    [SerializeField] private Transform BoomerangImgTF;
    bool isHit= false;

    public override void OnInit()
    {
        base.OnInit();
        speedBullet= 6;
    }
    private void Update()
    {
        BoomerangImgTF.Rotate(0, 0, 10, Space.Self);

        if(isHit)
        {
            float speed= speedBullet*Time.deltaTime;
            tf.position= Vector3.MoveTowards(tf.position, character.weaponGenTF.position, speed);
        }

        if(isHit  && Vector3.Distance(tf.position, character.weaponGenTF.position)<0.0001)
        {
            IsDead= true;
            
            //TODO: fix late
            SimplePool.Despawn(this);
        }
    }
    public override void OnDespawn()
    {
        isHit=true;
        base.OnDespawn();
    }
}
