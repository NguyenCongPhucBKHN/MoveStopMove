using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    
    void Update()
    {

        Move();
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(listCharInAttact.Count>0)
            {
                FaceTarget(listCharInAttact[0]);
                weapon.Attack();
            }
        }
        
    }

    public override void Move()
    {
        JoystickInput.Instance.Move();
    }
    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnDespawn()
    {
        Destroy(this.gameObject);
    }


}
