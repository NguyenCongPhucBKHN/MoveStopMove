using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Bullet
{
    private void Update()
    {
        
    }

     public override void OnDespawn()
    {
        IsDead= true;
        Destroy(this.gameObject);
    }

    

    
}
