using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
     float timer;
     float timerWait= 0.25f;
     float waitTime;
    public void OnEnter(Bot bot)
    {   
       
        // if(bot.Target!=null)
        // {
            
        //     bot.StopMoving();
        //     bot.ChangeAnim(Constant.ANIM_ATTACK);
        //     bot.Throw();
        //     if(waitTime> timerWait)
        //     {
        //         bot.Attack();
        //     }
            
        // }
        waitTime=0;
        timer=0;
    }
    public void OnExecute(Bot bot)
    {
         waitTime += Time.deltaTime;
         timer += Time.deltaTime;
         if(bot.Target!=null)
        {
            
            bot.StopMoving();
            bot.ChangeAnim(Constant.ANIM_ATTACK);
            bot.Throw();
            if(waitTime> timerWait)
            {
                bot.Attack();  
                bot.ChangeState( new IdleState());
            }
            
            
        }

        
        if(timer>= Constant.TIMER_ATTACK)
        {
            bot.ChangeState( new IdleState());
        }
    }
    public void OnExit(Bot bot)
    {
        
    }
}
