using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
     float timer;
    public void OnEnter(Bot bot)
    {
        bot.Attack();
    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if(timer>=0.5f)
        {
            bot.ChangeState( new PartrolState());
        }
    }
    public void OnExit(Bot bot)
    {
        
    }
}
