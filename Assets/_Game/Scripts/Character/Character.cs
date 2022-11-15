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
    [SerializeField] private Animator anim;
    public List<Character> listCharInAttact = new List<Character>();
    public Weapon weapon;
   
    public Vector3 dirAttact;
    public bool IsDead => !level.listCharacters.Contains(this);
    public bool isBullet= false;
    public bool IsAttack => listCharInAttact.Count>0;
    public EWeaponType currentWeaponType;
    private string currentAnimName;

    
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
        
        currentWeaponType= EWeaponType.Boomerang;
        SpawnWeapon();
        attackArea.character= this;
        dirAttact= TF.forward;
        
    }

    public void OnSpawn()
    {

    }

    public virtual void OnDespawn()
    {
        ChangeAnim(Constant.ANIM_DEAD);

    }

    public virtual void OnDeath()
    {
        StopMoving();
        ChangeAnim(Constant.ANIM_DEAD);
        Invoke(nameof(OnDespawn), Constant.TIMER_DEATH);
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

    
    public void ChangeAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
    public virtual void Move()
    {
        // ChangeAnim(Constant.ANIM_RUN);
    }
    public virtual void StopMoving()
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
    

    public void Scale()
    {
        Vector3 scale = TF.localScale;
        scale *= 1.05f;
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
        else
        {
            TF.forward= attackArea.transform.forward;
        }
    }

    public Character FindCharacterClosed()
    {
        Character closedChar = null;
        float distance = Mathf.Infinity;
        for(int i =0; i<listCharInAttact.Count; i++)
        {
            if(this.level.listCharacters.Contains(listCharInAttact[i]))
            {
                if(Vector3.Distance(TF.position, listCharInAttact[i].TF.position)< distance)
                {
                    closedChar = listCharInAttact[i];
                }
            }
        }
        return closedChar;
    }

    

    
    
}
