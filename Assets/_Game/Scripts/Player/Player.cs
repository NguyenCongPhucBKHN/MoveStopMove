using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private bool isStop => !JoystickInput.Instance.isControl;
    private bool canAttack => !JoystickInput.Instance.isMouse && weapon.isActiveAndEnabled;
    private void Start() {
        OnInit();
    }
    void Update()
    {
        if(level!=null)
        {

            if(GameManagerr.Instance.IsState(EGameState.GamePlay))
            {
                
               
               if(isStop && !(IsAttack) )
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }
                else if(isStop && canAttack && IsAttack &&  level.IsExistChar(FindCharacterClosed()))
                {
                    
                    StopMoving();
                    Throw();
                }
                else if(JoystickInput.Instance.isControl)
                {
                    ChangeAnim(Constant.ANIM_RUN);
                    Move();
                }
                

                
                    
                
            }
            if(GameManagerr.Instance.IsState(EGameState.Finish))
            {
                ChangeAnim(Constant.ANIM_DEAD);
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
        LevelManager.Instance.OnFinish();
        // GameManagerr.Instance.ChangeState(EGameState.Finish);
        ChangeAnim(Constant.ANIM_DEAD);
    }
    public override void Move()
    {

        base.Move();
        
        JoystickInput.Instance.Move();
    }


}
