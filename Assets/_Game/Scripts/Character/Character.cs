using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Character : MonoBehaviour, IHit
{
    // [SerializeField] private NavMeshAgent agent;
    // [SerializeField] public float chaseRange => Cylinder.transform.lossyScale.x;
    public Transform TF;
    public Level level;
    [SerializeField] public AttackArea attackArea;
    [SerializeField] public Weapon weaponPrefab;
    [SerializeField] float turnSpeed =10;
    public List<Character> listCharInAttact = new List<Character>();
    public Weapon weapon;
    public float distanceToTarget = Mathf.Infinity;
    public Vector3 dirAttact;
    public bool IsDead;
    public bool IsAttack => listCharInAttact.Count>0;
    
    void Awake()
    {
        TF= transform;
    }

    void Start()
    {
       OnInit();
    }
    
    
    public virtual  void OnInit()
    {
        SpawnWeapon();
        attackArea.character= this;
        dirAttact= TF.forward;
    }

    public void OnStart()
    {

    }

    public void OnSpawn()
    {

    }

    public virtual void OnDespawn()
    {
        
    }
    public void OnHit(Bullet bullet, Character character)
    {
        if(bullet.character!= this)
        {
            Destroy(bullet.gameObject);
            character.listCharInAttact.Remove(this);
            level.DespawnChar(this);
            this.IsDead = true;
            character.Scale();
        }
       
    }
    public void OnHitExit(Bullet bullet, Character character)
    {
        
    }

    public virtual void Move()
    {

    }
    

    public void Attack()
    {

    }

    public void SpawnWeapon()
    {
        Vector3 postion = TF.position;
        postion.y = TF.position.y;
        weapon = Instantiate(weaponPrefab, postion, TF.rotation);
        weapon.character = this;
        weapon.gameObject.transform.SetParent(TF);
        
    }
    public void Death()
    {

    }

    public void Scale()
    {
        Vector3 scale = TF.localScale;
        
        scale *= 1.1f;
        TF.localScale = scale;
        
    }
     public void SetSkin()
    {

    }
    public void SetWeapon()
    {

    }

   public void FaceTarget(Character target)
    {
            Vector3 position = target.TF.position;
            position.y = TF.position.y;
            Vector3 direction = (position - TF.position).normalized;
            TF.forward = direction;
            dirAttact= direction;
        
        
    }
    
}
