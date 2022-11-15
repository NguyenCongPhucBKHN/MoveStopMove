using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private float speedBot=15;
    List<Character> chars => level.listCharacters;
    public Character Target => FindCharacterClosed();
    bool isDis= false;
    Vector3 destination;
    public IState<Bot> currentState;
    Vector3 point;
    public bool IsDestination
    {
        get
        {
            point = TF.position;
            point.y = destination.y;
            return Vector3.Distance(destination, point) < Constant.DISTANCE_DESTINATION;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState != null && !IsDead)
        {
            currentState.OnExecute(this);
            // Attack();
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        destination = TF.position;
        ChangeState(new IdleState());
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(this.gameObject);
    }

    public override void OnDeath()
    {
        ChangeState(null);
        base.OnDeath();
    }

    public void ChangeState(IState<Bot> newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    private Character SelectCharTarget()
    {
        Character target = null;

        /*Random target*/
        int rand =Random.Range(0, chars.Count);
        if(chars[rand]!= this)
        {
            target = chars[rand];
        }
        return target;

        //Find closest target
        // float minDistance = Mathf.Infinity;
        // for (int i =0; i< chars.Count; i++)
        // {
        //     if(chars[i]!= this && (Vector3.Distance(TF.position, chars[i].TF.position)< minDistance) )
        //     {
        //         target = chars[i];
        //         minDistance = Vector3.Distance(TF.position, chars[i].TF.position);
        //     }
            
        // }
        // return target;
    }



    public override void Move()
    {   
        
        // base.Move();
        isDis = true;
        if(isDis)
        {

            agent.speed=speedBot;

            if(!IsDestination)
            {
                ChangeAnim(Constant.ANIM_RUN);
                agent.SetDestination(destination);   
            }
            else
            {
                ChangeState(new IdleState());
                destination = level.GenPointTarget();
                destination.y = TF.position.y;
            }
        }
        
    }

    public override void StopMoving()
    {
        
        agent.speed= 0;
    }
    public void Attack()
    {
        if(listCharInAttact.Count>0&& level.listCharacters.Contains(FindCharacterClosed()))
        {
            FaceTarget(FindCharacterClosed());
            ChangeAnim(Constant.ANIM_ATTACK);
            weapon.Attack();
        }
    }
   
}
