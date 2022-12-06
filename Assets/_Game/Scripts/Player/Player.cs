using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    
    private bool isStop => !JoystickInput.Instance.isControl;
    private bool canAttack => !JoystickInput.Instance.isMouse && weapon.isActiveAndEnabled;

    [Header("Transform for Skins")]
    public Transform HatTF;
    public Transform ShieldTF;
    public Transform WingTF;
    public Transform TailTF;

    public SkinnedMeshRenderer pantRender;
    public SkinnedMeshRenderer skinRender;

    private void Start() {
        OnInit();
        DataPlayerController.AddWeapon(0, 0);
    }
    void Update()
    {
        if(level!=null)
        {
            if(GameManagerr.Instance.IsState(EGameState.GamePlay))
            { 
               if(isStop && !(IsAttack) ) // Dung va co bot trong vung tan cong
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }
                else if(isStop && canAttack && IsAttack &&  level.IsExistChar(FindCharacterClosed())) // Dung va co the tan cong, co bot trong vung tan cong
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
        string name = "You";
        float score = Random.Range(0,5);
        EBodyMaterialType body = EBodyMaterialType.YELLOW;
        // data = new CharacterData(name, score, body);
        data?.SetBodyMaterial(body);
        skinnedMeshRenderer.material = data?.GetBodyMaterial();
        data?.SetName(name);
        data?.SetScore(score);
        if(indicator==null || !indicator.gameObject.activeSelf)
        {
            indicator = SimplePool.Spawn<Indicator>(indicatorprefab);
            indicator.SetOwnCharacter(this);
        }
        currentWeaponType= (EWeaponType) DataPlayerController.GetCurrentWeapon().indexType;
        int idmaterial =  DataPlayerController.GetCurrentWeapon().indexItem;
        SpawnWeapon(idmaterial);
        attackArea.character= this;
        dirAttact= TF.forward;
        PresentSkin.Instance.SelectItem();
        
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public override void OnDespawn()
    {
        if(indicator!= null)
        {
            indicator.OnDespawn();
        }
        
        indicator= null;

        this.gameObject.SetActive(false);
    }

    public override void OnDeath()
    {
        base.OnDeath();
        ChangeAnim(Constant.ANIM_DEAD);
        level.isWin = false;
        LevelManager.Instance.OnFinish();
    }
    public override void Move()
    {
        
        if(GameManagerr.Instance.IsState(EGameState.GamePlay))
        {
            JoystickInput.Instance.Move();
            base.Move();
        }
        
    }


}
