using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private void Start() {
        ChangeAnim(Constant.ANIM_IDLE);
    }
    void Update()
    {
        if(level!=null)
        {
            

            if(GameManagerr.Instance.IsState(EGameState.GamePlay))
            {
                Move();
                Debug.Log("JoystickInput.Instance.isControl: "+JoystickInput.Instance.isControl);
                if(JoystickInput.Instance.isControl)
                {
                    ChangeAnim(Constant.ANIM_RUN);
                }
                else
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }
                
            }
            
            
            if(Input.GetKeyDown(KeyCode.A))
            {
                if(listCharInAttact.Count>0 )
                {
                    FaceTarget(FindCharacterClosed());
                    ChangeAnim(Constant.ANIM_ATTACK);
                    weapon.Attack();
                }
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Number character in range attact: "+ listCharInAttact.Count);
            }
        }

        
        
    }

    
    public override void OnInit()
    {
        base.OnInit();
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(this.gameObject);
    }

    public override void OnDeath()
    {
        base.OnDeath();
        ChangeAnim(Constant.ANIM_DEAD);
    }
    public override void Move()
    {

        base.Move();
        
        JoystickInput.Instance.Move();
    }


}
