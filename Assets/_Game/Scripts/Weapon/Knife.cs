using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Bullet
{
    
    private void Update()
    {
        
    }
    public override void OnInit()
    {
        // base.OnInit();
        speedBullet= 6;
    }

     public override void OnDespawn()
    {
        base.OnDespawn();
    }

    

    
}
