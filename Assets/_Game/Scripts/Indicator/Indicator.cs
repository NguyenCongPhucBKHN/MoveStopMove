using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : GameUnit
{
    // [HideInInspector]
   public  Character ownIndicator;
    private Transform target;
    public GameObject followImage;
    public GameObject nameTxtObj;
    public Image scoreHolder;
    public Text scoreTxt;
    public Text nameTxt;
    public Image Arrow;


    private Material indicatorMat;

    private bool nameActivate;


    Player player;

    // void Start()
    // {
    //     player = FindObjectOfType<Player>();
    // }
    
    void Update()
    {
        Vector2 inputVector = new Vector2( target.position.x, target.position.z);
        float angle =  Vector2.SignedAngle(Vector2.up, inputVector);
        Arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(!ownIndicator.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        if(target!= null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
            nameActivate = true;
            if (screenPos.x < 0)
            {
                screenPos.x = 15;
                nameActivate = false;
            }
            else if (screenPos.x > Screen.width)
            {
                screenPos.x = Screen.width -10;
                nameActivate = false;
            }
            if (screenPos.y < 0)
            {
                screenPos.y = 10;
                nameActivate = false;
            }
            else if (screenPos.y > Screen.height)
            {
                screenPos.y = Screen.height -10;
                nameActivate = false;
            }

            // Set UI state
            if (nameTxtObj.activeInHierarchy == false && nameActivate)
            {
                
                nameTxtObj.SetActive(true);
                
            }
            else if (nameTxtObj.activeInHierarchy == true && !nameActivate)
            {
                Arrow.gameObject.SetActive(true);
                nameTxtObj.SetActive(false);
                
            }

            Vector2 pos = new Vector2(screenPos.x, screenPos.y );

            followImage.transform.position =/* screenPos.y  + Screen.height / 8 > Screen.height? pos: */new Vector2(screenPos.x, screenPos.y  + Screen.height / 8);
        }
    }
    public void SetOwnCharacter(Character charr)
    {
        ownIndicator = charr;
        SetTarget();
        SetMaterial();
        SetScore();
        SetName();
    }
    void SetTarget()
    {
        target= ownIndicator.tf;
    }

    public void SetScore()
    {
        
        scoreTxt.text = ownIndicator?.data?.GetScore().ToString();
    }

    public void SetName()
    {
        nameTxt.text = ownIndicator.data.GetName();
    }

    public void SetMaterial()
    {
        indicatorMat = ownIndicator?.data?.GetBodyMaterial();
        if(indicatorMat!= null)
        {
            nameTxt.color = indicatorMat.color;
            scoreHolder.color = indicatorMat.color;
        }
        
       
    }

    void RotationArrow()
    {
        Arrow.transform.LookAt(ownIndicator.tf, Vector3.forward);
    }

    public override void OnInit()
    {
        
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
