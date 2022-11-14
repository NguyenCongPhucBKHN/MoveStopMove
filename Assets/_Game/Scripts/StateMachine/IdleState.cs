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
       timer =0;
       randomTime = Random.Range(0.5f, 2f);

    }
    public void OnExecute(Bot bot)
    {
        timer+= Time.deltaTime;
        if(bot.IsAttack)
        {
            bot.ChangeState(new AttackState());
        }
        if(timer>randomTime)
        {
            bot.ChangeState(new PartrolState());
        }

    }
    public void OnExit(Bot bot)
    {
        
    }
}
    

