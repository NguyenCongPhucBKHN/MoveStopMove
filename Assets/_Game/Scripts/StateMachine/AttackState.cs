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
            // bot.FaceTarget(bot.Target);
            bot.StopMoving();
            bot.Attack();
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
