using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    float randomTime;
    float timer;
    float waitTime ;
    public void OnEnter(Bot bot)
    {
        bot.StopMoving();
        bot.ChangeAnim(Constant.ANIM_IDLE);
        timer =0;
        waitTime = Random.Range(1f, 3f);
        randomTime = Random.Range(Constant.TIMER_MIN_IDLE, Constant.TIMER_MAX_IDLE);
    }
    public void OnExecute(Bot bot)
    {
        timer+= Time.deltaTime;
        if(timer> randomTime)
        {
            bot.ChangeState(new PartrolState());
        }

        if(bot.IsAttack && timer> waitTime)
        {
            bot.ChangeState(new AttackState());
        }
        // if(timer>randomTime)
        // {
        //     bot.ChangeState(new PartrolState());
        // }

    }
    public void OnExit(Bot bot)
    {
        
    }
}
    

