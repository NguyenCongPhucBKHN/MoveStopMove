using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : GameUnit
{
    // [HideInInspector]
   public  Character ownIndicator;
    private Transform target; // Target
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
    Vector3 viewPoint;

    Player player;

    void Update()
    {
        if(target!=null)
        {
            viewPoint = Camera.main.WorldToViewportPoint(target.position);
            Debug.Log("viewPoint begin: "+ viewPoint);
            nameActivate = true;

            if (viewPoint.x < 0)
            {
                viewPoint.x = 0.1f;
                nameActivate = false;
            }
            else if (viewPoint.x > 1)
            {
                viewPoint.x = 0.9f;
                nameActivate = false;
            }
            if (viewPoint.y < 0)
            {
                viewPoint.y = 0.1f;
                nameActivate = false;
            }
            else if (viewPoint.y > 1)
            {
                viewPoint.y = 0.9f;
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
            Debug.Log("viewPoint: "+ viewPoint);
            
            // Vector2 pos = new Vector2(screenPos.x, screenPos.y );
            Vector3 posFollowWorld = Camera.main.ViewportToWorldPoint(viewPoint);
            Vector3 posFollowScreen = Camera.main.WorldToScreenPoint(posFollowWorld);

            if(!nameActivate)
            {
                
                followImage.transform.position = new Vector2(posFollowScreen.x, posFollowScreen.y);
                Vector3 arrowViewPoint = Camera.main.WorldToScreenPoint(ArrowTF.position);
                Vector3 dir = (arrowViewPoint - viewPoint);
                dir.z = 0f;
                dir.Normalize();
                ArrowTF.up = dir;
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

    bool IsOnScreen()
    {
        if(target!= null)
        {
            screenPos = Camera.main.WorldToScreenPoint(target.position);
            return !((screenPos.x < 0)|| (screenPos.x > Screen.width) ||(screenPos.y<0)||(screenPos.y > Screen.height));
        }
        return false;
    }

     private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        float angle = 0;
        
        angle = Vector3.Angle (vec1, vec2);
        //We get the sign (1 or -1) depending the position of the vectors using the foward direction
        float sign = Mathf.Sign(Vector3.Dot(Vector3.forward,Vector3.Cross(vec1,vec2)));
        float signed_angle = angle * sign;
        //We return the angle
        return signed_angle;
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
