using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
     float timer;
    public void OnEnter(Bot bot)
    {
        if(bot.Target!=null)
        {
            bot.StopMoving();
            bot.ChangeAnim(Constant.ANIM_ATTACK);
            bot.Throw();
        }
        timer=0;
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if(timer>= Constant.TIMER_ATTACK)
        {
            bot.ChangeState( new IdleState());
        }
    }
    public void OnExit(Bot bot)
    {
        
    }
}
