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
               if(isStop && !(IsAttack) )
                {
                    ChangeAnim(Constant.ANIM_IDLE);
                }
                else if(isStop && canAttack && IsAttack &&  level.IsExistChar(FindCharacterClosed()))
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
                ChangeAnim(Constant.ANIM_DEAD);
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
        Indicator indicator = Instantiate(indicatorprefab);
        indicator.SetOwnCharacter(this);
        currentWeaponType= (EWeaponType) DataPlayerController.GetCurrentWeapon().indexType;
        int idmaterial =  DataPlayerController.GetCurrentWeapon().indexItem;
        SpawnWeapon(idmaterial);
        attackArea.character= this;
        dirAttact= TF.forward;
        
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(this.gameObject);
    }

    public override void OnDeath()
    {
        base.OnDeath();
        LevelManager.Instance.OnFinish();
        // GameManagerr.Instance.ChangeState(EGameState.Finish);
        ChangeAnim(Constant.ANIM_DEAD);
    }
    public override void Move()
    {

        base.Move();
        
        JoystickInput.Instance.Move();
    }


}
