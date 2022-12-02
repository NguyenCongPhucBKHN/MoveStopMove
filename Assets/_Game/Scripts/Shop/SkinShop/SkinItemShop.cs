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
    void Select()
    {
        PresentSkin.Instance.currentIndex = indexItem;
        PresentSkin.Instance.currentType = indexType;
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
}
