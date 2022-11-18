using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Bullet //Bua
{
    [SerializeField] Transform HammerImgTF;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        HammerImgTF.Rotate(0, 0, 5f, Space.Self);
    }

    public override void OnInit()
    {
        speedBullet= 5;
    }
     public override void OnDespawn()
    {
        base.OnDespawn();
        IsDead= true;
        Destroy(this.gameObject);
    }

}
