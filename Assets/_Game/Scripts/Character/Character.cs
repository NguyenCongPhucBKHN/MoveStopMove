using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Character : MonoBehaviour, IHit
{
    // [SerializeField] private NavMeshAgent agent;
    // [SerializeField] public float chaseRange => Cylinder.transform.lossyScale.x;
    public Transform TF;
    public Level level;
    [SerializeField] public WeaponDatas weaponDatas;
    [SerializeField] public AttackArea attackArea;
    [SerializeField] public Weapon weaponPrefab;
    [SerializeField] public Transform weaponGenTF;
    [SerializeField] float turnSpeed =10;
    
    public List<Character> listCharInAttact = new List<Character>();
    public Weapon weapon;
    public float distanceToTarget = Mathf.Infinity;
    public Vector3 dirAttact;
    public bool IsDead => !level.listCharacters.Contains(this);
    public bool isBullet= false;
    public bool IsAttack => listCharInAttact.Count>0;
    public EWeaponType currentWeaponType;

    
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
        currentWeaponType= EWeaponType.Knife;
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
            bullet.OnDespawn();
            character.listCharInAttact.Remove(this);
            level.DespawnChar(this);
            character.Scale();
        }  
    }
    public void OnHitExit(Bullet bullet, Character character)
    {
        
    }

    public virtual void Move()
    {

    }
    
    public void SpawnWeapon()
    {
        weaponPrefab = weaponDatas.GetWeaponPrefab(currentWeaponType);
        Vector3 postion = weaponGenTF.position;
        postion.y = weaponGenTF.position.y;
        weapon = Instantiate(weaponPrefab, weaponGenTF);
        weapon.transform.position= postion; 
        weapon.character = this;
        isBullet = true;
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
        if(this.level.listCharacters.Contains(target))
        {
            Vector3 position = target.TF.position;
            position.y = TF.position.y;
            Vector3 direction = (position - TF.position).normalized;
            TF.forward = direction;
            dirAttact= direction;
        }
        
            
    }
    
}
