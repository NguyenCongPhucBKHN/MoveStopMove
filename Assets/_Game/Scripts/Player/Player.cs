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
            if(listCharInAttact.Count>0 )
            {
                FaceTarget(listCharInAttact[0]);
                ChangeAnim(Constant.ANIM_ATTACK);
                weapon.Attack();
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Number character in range attact: "+ listCharInAttact.Count);
        }
        
    }

    
    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(this.gameObject);
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }
    public override void Move()
    {
        base.Move();
        JoystickInput.Instance.Move();
    }


}
