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
    [SerializeField] public SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] public ListWeaponMaterials listWeaponMaterials;
    float turnSpeed =8;
    [SerializeField] private Animator anim;
    public List<Character> listCharInAttact = new List<Character>();
    public Weapon weapon;
    public CharacterData data;
    public Indicator indicatorprefab;
    
    public Vector3 dirAttact = Vector3.zero;
   
    public bool isBullet= false;
     public bool IsDead 
    {
        get
        {
           return  !level.listCharacters.Contains(this);
        }
    } 
    public bool IsAttack 
    {
        get 
        {
            return listCharInAttact.Count>0;
        }
    }
    public EWeaponType currentWeaponType;
    private string currentAnimName;
    public bool isDie;

    
    
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
        int index = Random.Range(0, BotDatasIns.BotName.Count);
        string name = BotDatasIns.BotName[index];
        float score = Random.Range(0,5);
        EBodyMaterialType body = RandomBodyMat();
        // data = new CharacterData(name, score, body);
        data?.SetBodyMaterial(body);
        skinnedMeshRenderer.material = data?.GetBodyMaterial();
        data?.SetName(name);
        data?.SetScore(score);
        Indicator indicator = Instantiate(indicatorprefab);
        indicator.SetOwnCharacter(this);
        currentWeaponType=  (EWeaponType) Random.Range(0, Constant.NUMBER_WEAPONS);
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
        isDie= true;
        StopMoving();
        ChangeAnim(Constant.ANIM_DEAD);
        Invoke(nameof(OnDespawn), Constant.TIMER_DEATH);
    }
    
    public void OnHit(Bullet bullet, Character character)
    {
        if(bullet.character!= this)
        {
            
            character.listCharInAttact.Remove(this);
            bullet.OnDespawn();
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
       
    }
    public virtual void StopMoving()
    {
        
    }
    public void SpawnWeapon()
    {
        // weapon.indexMat = Random.Range(0, 3);
        weaponPrefab = weaponDatas.GetWeaponPrefab(currentWeaponType);
        Vector3 postion = weaponGenTF.position;
        postion.y = weaponGenTF.position.y;
        weapon = Instantiate(weaponPrefab, weaponGenTF);
        weapon.InitData(weapon.indexMat, (int) currentWeaponType );
        weapon.transform.position= postion; 
        weapon.character = this;
        isBullet = true;
    }

    public void SpawnWeapon(int material)
    {
        weaponPrefab = weaponDatas.GetWeaponPrefab(currentWeaponType);
        Vector3 postion = weaponGenTF.position;
        postion.y = weaponGenTF.position.y;
        weapon = Instantiate(weaponPrefab, weaponGenTF);
        weapon.indexMat = material;
        weapon.InitData(weapon.indexMat,(int) currentWeaponType);
        weapon.transform.position= postion; 
        weapon.character = this;
        isBullet = true;
    }


    public void Scale()
    {
        Vector3 scale = TF.localScale;
        scale *= 1.07f;
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

    public bool AnimatorIsPlaying(){
     return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
  }

    public void Throw()
    {
        if(listCharInAttact.Count>0 && level.IsExistChar(FindCharacterClosed()))
        {
            FaceTarget(FindCharacterClosed());
            ChangeAnim(Constant.ANIM_ATTACK);
            weapon.gameObject.SetActive(false);
            weapon.Attack();

        }
    }

    public EBodyMaterialType RandomBodyMat()
    {
        EBodyMaterialType  body = EBodyMaterialType.YELLOW;
        if(level!=null)
        {
            int index = (int)Random.Range(0, (float)(level?.listBodyMaterialType.Count));
            body = level.listBodyMaterialType[index];
            level.listBodyMaterialType.RemoveAt(index);
        }
        return  body;
    }

    public virtual void InitData()
    {
        int index = Random.Range(0, BotDatasIns.BotName.Count);
        string name = BotDatasIns.BotName[index];
        float score = Random.Range(0,5);
        EBodyMaterialType body = RandomBodyMat();
        // data = new CharacterData(name, score, body);
        data?.SetBodyMaterial(body);
        skinnedMeshRenderer.material = data?.GetBodyMaterial();
        data?.SetName(name);
        data?.SetScore(score);
    }

    
    
}
