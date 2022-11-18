using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private bool isStop => !JoystickInput.Instance.isControl;
    private bool canAttack => !JoystickInput.Instance.isMouse;
    private void Start() {
        OnInit();
    }
    void Update()
    {
        if(level!=null)
        {
            if(GameManagerr.Instance.IsState(EGameState.GamePlay))
            {
                
                if(isStop && canAttack && listCharInAttact.Count>0 &&  level.IsExistChar(FindCharacterClosed()))
                {
                    
                    StopMoving();
                    // ChangeAnim(Constant.ANIM_ATTACK);
                    Attack();
                }
                
                else if(JoystickInput.Instance.isControl)
                {
                    ChangeAnim(Constant.ANIM_RUN);
                    Move();
                }
                else if(isStop && !(listCharInAttact.Count>0) )
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }

                
                    
                
            }
            if(GameManagerr.Instance.IsState(EGameState.Finish))
            {
                ChangeAnim(Constant.ANIM_DEAD);
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
        GameManagerr.Instance.ChangeState(EGameState.Finish);
        ChangeAnim(Constant.ANIM_DEAD);
    }
    public override void Move()
    {

        base.Move();
        
        JoystickInput.Instance.Move();
    }


}
