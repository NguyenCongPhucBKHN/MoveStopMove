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


    private Material indicatorMat;

    private bool nameActivate;
    Vector3 screenPos;

    Player player;

    void Update()
    {
        
        // Vector2 inputVector = new Vector2(target.position.x, target.position.z);
        // Vector2 arrowPos = new Vector2(Arrow.transform.position.x, Arrow.transform.position.y);
        // float angle =  AngleBetweenVector2(arrowPos, inputVector);
        // Arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // if(!ownIndicator.gameObject.activeSelf)
        // {
        //     this.gameObject.SetActive(false);
        // }
        // if(target!= null)
        // {
        //     screenPos = Camera.main.WorldToScreenPoint(target.position);
        //     nameActivate = true;
        //     if (screenPos.x < 0)
        //     {
        //         screenPos.x = 15;
        //         nameActivate = false;
        //     }
        //     else if (screenPos.x > Screen.width)
        //     {
        //         screenPos.x = Screen.width -10;
        //         nameActivate = false;
        //     }
        //     if (screenPos.y < 0)
        //     {
        //         screenPos.y = 20;
        //         nameActivate = false;
        //     }
        //     else if (screenPos.y > Screen.height)
        //     {
        //         screenPos.y = Screen.height -20;
        //         nameActivate = false;
        //     }

        //     // Set UI state
        //     if (nameTxtObj.activeInHierarchy == false && nameActivate)
        //     {
        //         Arrow.gameObject.SetActive(false);
        //         nameTxtObj.SetActive(true);
                
        //     }
        //     else if (nameTxtObj.activeInHierarchy == true && !nameActivate)
        //     {
        //         Arrow.gameObject.SetActive(true);
        //         nameTxtObj.SetActive(false);
                
        //     }
            
        //     Vector2 pos = new Vector2(screenPos.x, screenPos.y );
            
        //     followImage.transform.position = screenPos.y  + Screen.height / 8 > Screen.height   ?new Vector2(pos.x, pos.y - Screen.height / 15): new Vector2(screenPos.x, screenPos.y  + Screen.height / 10);
            
            
           
        // }
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
