using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    
    // private bool isStop => !JoystickInput.Instance.isControl;
    private bool canAttack => /*!JoystickInput.Instance.isMouse && */ weapon.isActiveAndEnabled;

    [Header("Transform for Skins")]
    public Transform HatTF;
    public Transform ShieldTF;
    public Transform WingTF;
    public Transform TailTF;

    public SkinnedMeshRenderer pantRender;
    public SkinnedMeshRenderer skinRender;

    private void Start() {
        // OnInit();
        DataPlayerController.AddWeapon(0, 0);
    }
    void Update()
    {
        if(level!=null)
        {
            if(GameManagerr.Instance.IsState(EGameState.GamePlay))
            { 
               if(!JoystickInput.Instance.isControl && !isAttack()) // Dung va co bot trong vung tan cong
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }
                else if(!JoystickInput.Instance.isControl && canAttack && isAttack() &&  level.IsExistChar(FindCharacterClosed())) // Dung va co the tan cong, co bot trong vung tan cong
                {
                    StopMoving();
                    Throw();
                }
                
                else if(JoystickInput.Instance.isControl)
                {
                    ChangeAnim(Constant.ANIM_RUN);
                    Move();
                }
            }
            if(GameManagerr.Instance.IsState(EGameState.Finish))
            {
                if(!LevelManager.Instance.currentLevel.isWin)
                {
                    ChangeAnim(Constant.ANIM_DEAD);
                }
                else
                {
                    ChangeAnim(Constant.ANIM_WIN);
                }
                
            }
        }
    }

    public override void OnInit()
    {
        this.gameObject.SetActive(true);
        IsDead= false;
        AssignAttackArea();
        SetData();
        SetSkin();
        SetWeapon();
        SetIndicator();
        ChangeAnim(Constant.ANIM_IDLE);
    }

    void SetData()
    {
        string name = "You";
        // float score = 0;
        EBodyMaterialType body = EBodyMaterialType.YELLOW;
        data?.SetBodyMaterial(body);
        skinnedMeshRenderer.material = data?.GetBodyMaterial();
        data?.SetName(name);
        data?.SetScore(score);
        
    }

    public override void SetSkin()
    {
        // DespawnCurrentWeapon();
        PresentSkin.Instance.EquippedItem();
        // PresentSkin.Instance.SelectItem();
    }

    public override void SetWeapon()
    {
        DespawnCurrentWeapon();
        currentWeaponType= (EWeaponType) DataPlayerController.GetCurrentWeapon().indexType;
        int idmaterial =  DataPlayerController.GetCurrentWeapon().indexItem;
        SpawnWeapon(idmaterial);
    }

    public override void OnDespawn()
    {
        indicator.OnDespawn();
        this.gameObject.SetActive(false);
    }

    public override void OnDeath()
    {
        listCharInAttact.Clear();
        ChangeAnim(Constant.ANIM_DEAD);
        base.OnDeath();
        LevelManager.Instance.OnFinish();
        level.isWin = false;
    }
    public override void Move()
    {
        if(GameManagerr.Instance.IsState(EGameState.GamePlay))
        {  
            JoystickInput.Instance.Move();
            base.Move();
        }
        
    }
    public void DespawnCurrentWeapon()
    {
        Weapon[] listWeapon = weaponGenTF.GetComponentsInChildren<Weapon>();
        for(int i =0; i< listWeapon.Length; i++)
        {
            Destroy(listWeapon[i].gameObject);
        }
    }


}
