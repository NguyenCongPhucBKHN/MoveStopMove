using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
     float timer;
    public void OnEnter(Bot bot)
    {
        if(bot.Target != null)
        {
            bot.FaceTarget(bot.Target);
            bot.Move();
            if(bot.IsAttack)
            {
                bot.Attack();
            }
            
        }
        timer =0;

    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if(timer>=1.5f)
        {
            bot.ChangeState( new PartrolState());
        }
    }
    public void OnExit(Bot bot)
    {
        
    }
}
