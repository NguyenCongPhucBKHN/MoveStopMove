using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    float randomTime;
    float timer;
    public void OnEnter(Bot bot)
    {
       bot.StopMoving();
       bot.ChangeAnim(Constant.ANIM_IDLE);
       timer =0;
       randomTime = Random.Range(Constant.TIMER_MIN_IDLE, Constant.TIMER_MAX_IDLE);
    }
    public void OnExecute(Bot bot)
    {
        timer+= Time.deltaTime;
        if(timer> randomTime)
        {
            bot.ChangeState(new PartrolState());
        }
        // if(bot.IsAttack)
        // {
        //     bot.ChangeState(new AttackState());
        // }
        // if(timer>randomTime)
        // {
        //     bot.ChangeState(new PartrolState());
        // }

    }
    public void OnExit(Bot bot)
    {
        
    }
}
    

