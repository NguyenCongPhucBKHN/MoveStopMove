using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : GameUnit
{
    // [HideInInspector]
   public  Character ownIndicator;
    [SerializeField]private Transform target; // Target
    public GameObject followImage;
    public GameObject nameTxtObj;
    public Image scoreHolder;
    public Text scoreTxt;
    public Text nameTxt;
    public Image Arrow;
    public Transform ArrowTF;


    private Material indicatorMat;

    private bool nameActivate;
    Vector3 screenPos;
    [SerializeField]Vector3 viewPoint;
    [SerializeField] Vector3 possiontion;

    Player player;

    void Update()
    {
        if(target!=null)
        {
            viewPoint = Camera.main.WorldToViewportPoint(target.position);
            possiontion = viewPoint;

            nameActivate = true;



            if (viewPoint.x < 0 || possiontion.x <0 ) /*&& possiontion.x >0)*/
            {
                viewPoint.x = 0.1f;
                nameActivate = false;
            }
            else if (viewPoint.x > 1 )
            {
                viewPoint.x = 0.9f;
                nameActivate = false;
            }
            if (viewPoint.y < 0) /*&& possiontion.y >-100) */ //Done
            {
                viewPoint.y = 0.1f;
                nameActivate = false;
            }
            else if (viewPoint.y > 1 ||  possiontion.y <-100 )
            {
                viewPoint.y = 0.95f;
                nameActivate = false;
            }

            // Set UI state
            if (nameTxtObj.activeInHierarchy == false && nameActivate)
            {
                Arrow.gameObject.SetActive(false);
                nameTxtObj.SetActive(true);
                
            }
            else if (nameTxtObj.activeInHierarchy == true && !nameActivate)
            {
                Arrow.gameObject.SetActive(true);
                nameTxtObj.SetActive(false);
                
            }
            

            
            // Vector3 posFollowWorld = Camera.main.ViewportToWorldPoint(viewPoint);
             Vector3 posFollowScreen = Camera.main.ViewportToScreenPoint(viewPoint);

            if(!nameActivate)
            {
                
                 followImage.transform.position = new Vector2(posFollowScreen.x, posFollowScreen.y);
                // Vector3 arrowViewPoint = Camera.main.WorldToViewportPoint(ArrowTF.position);
                Vector3 dir = (viewPoint - new Vector3(0.5f, 0.5f,0));
                dir.z =0;
                // Vector2 dirr = Camera.main.ViewportToWorldPoint(dir);
                dir.Normalize();
                if(viewPoint.y>0.945f)
                {
                     ArrowTF.up = dir;
                }
                else
                {
                    ArrowTF.up = dir; 
                }
                
                
            }
            else
            {
                Vector3 pos2 = viewPoint + new Vector3(0, 0.1f, 0);
                Vector3 posFollowWorld2 = Camera.main.ViewportToWorldPoint(pos2);
                Vector3 posFollowScreen2 = Camera.main.WorldToScreenPoint(posFollowWorld2);
                followImage.transform.position = new Vector2(posFollowScreen2.x, posFollowScreen2.y);
                followImage.transform.rotation =  Quaternion.identity;
            }
            
            
        }


    }

   

    public void SetOwnCharacter()
    {
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
            Arrow.color = indicatorMat.color;
        }
    }
    public Material GetMaterial()
    {
        return  indicatorMat;
    }

    public override void OnInit()
    {
        SetOwnCharacter();
    }

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
