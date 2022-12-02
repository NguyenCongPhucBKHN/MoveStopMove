using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    // [HideInInspector]
   public  Character ownIndicator;
    private Transform target;
    public GameObject followImage;
    public GameObject nameTxtObj;
    public Image scoreHolder;
    public Text scoreTxt;
    public Text nameTxt;


    private Material indicatorMat;

    private bool nameActivate;

    
    void Update()
    {
        if(target!= null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
            nameActivate = true;
            if (screenPos.x < 0)
            {
                screenPos.x = Screen.width / 12;
                nameActivate = false;
            }
            else if (screenPos.x > Screen.width)
            {
                screenPos.x = Screen.width * 11 / 12;
                nameActivate = false;
            }
            if (screenPos.y < 0)
            {
                screenPos.z = Screen.height* 4/ 15;
                nameActivate = false;
            }
            else if (screenPos.y > Screen.height)
            {
                screenPos.z = Screen.height * 11 / 15;
                nameActivate = false;
            }

            // Set UI state
            if (nameTxtObj.activeInHierarchy == false && nameActivate)
            {
                nameTxtObj.SetActive(true);
            }
            else if (nameTxtObj.activeInHierarchy == true && !nameActivate)
            {
                nameTxtObj.SetActive(false);
            }
            followImage.transform.position = new Vector2(screenPos.x, screenPos.y + Screen.height / 8);
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
        target= ownIndicator.TF;
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

}
