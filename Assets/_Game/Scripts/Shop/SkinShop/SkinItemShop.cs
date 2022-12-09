using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SkinItemShop : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private ESkinType indexType;
    [SerializeField] private int indexItem;
    [SerializeField] private GameObject lockObj;
    
    
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Select);
    }
    void Select() // Chon tung item
    {
        PresentSkin.Instance.currentIndex = indexItem;
        PresentSkin.Instance.currentType = indexType;
        UpdateBtn();
        PresentSkin.Instance.SpawnItem();
    }
    void Update()
    {
        if(DataPlayerController.IsOwnedSkin((int)indexType, indexItem))
        {
            lockObj.SetActive(false);
        }
        else
        {
            lockObj.SetActive(true);
        }
    }

    void UpdateBtn()
    {
        int num;
        if(PresentSkin.Instance.isUsed((int) indexType,  indexItem)) // Dang mang skin nay
        {
            num = 100;
        }
        else if(DataPlayerController.IsOwnedSkin((int) indexType,  indexItem)) // Dang so huu
        {
            num = 10;
        }
        else
        {
            num =1;
        }
        // PresentSkin.Instance.ActivateBtn(num);
    }

   
}
