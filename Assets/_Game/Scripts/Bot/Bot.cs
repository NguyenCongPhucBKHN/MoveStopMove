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
    public Character Target => SelectCharTarget();
    public IState<Bot> currentState;
    
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
        ChangeAnim(Constant.ANIM_RUN);
        base.Move();
        agent.speed=speedBot;
        // Character target = SelectCharTarget();
        // if(target!=null)
        // {
        //     distanceToTarget = Vector3.Distance(target.TF.position, TF.position);
        //     if(distanceToTarget > 1f)
        //     {
        //         agent.SetDestination(target.TF.position);
        //     }
        // } 
        Vector3 position = level.GenPointTarget();
              distanceToTarget = Vector3.Distance(position, TF.position);
            if(distanceToTarget > 1f)
            {
                agent.SetDestination(position);
            }

    }

    public override void StopMoving()
    {
        // ChangeAnim(Constant.ANIM_IDLE);
        agent.speed= 0;
    }
    public void Attack()
    {
        if(listCharInAttact.Count>0&& level.listCharacters.Contains(listCharInAttact[0]))
        {
            FaceTarget(listCharInAttact[0]);
            ChangeAnim(Constant.ANIM_ATTACK);
            SpawnBullet();
            // Invoke(nameof(SpawnBullet), 2f);
        }
    }

    public void SpawnBullet()
    {
        ChangeAnim(Constant.ANIM_ATTACK);
        weapon.Attack();
    }
   
}
