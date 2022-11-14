using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartrolState : IState<Bot>
{
    float randomTime;
    float timer;
    public void OnEnter(Bot bot)
    {
       timer = 0;
       randomTime = Random.Range(3f, 6f);

    }
    public void OnExecute(Bot bot)
    {
        timer += Time.deltaTime;
        if(timer<randomTime)
        {
            bot.Move();
        }
        else
        {
            bot.ChangeState(new IdleState());
        }


        //  if(bot.Target!= null)
        //  {
        //     // bot.FaceTarget(bot.Target);
        //     if(bot.IsAttack)
        //     {
        //         bot.Attack();
        //     }
        //     else
        //     {
        //         bot.Move();
        //     }
        //  }
        //  else
        // {
        //     if (timer < randomTime)
        //     {
        //         bot.Move();
        //     }
        //     else
        //     {
        //         bot.ChangeState(new IdleState());
        //     }
        // }
         

    }
    public void OnExit(Bot bot)
    {
        
    }
}
