using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatGenSkin : GenSkin
{
    [SerializeField] HatDatas hatDatas;
    private GameObject prefab;
    private GameObject Hat;
    private Dictionary<GameObject, GameObject> dictHat = new Dictionary<GameObject, GameObject>();
    private  Transform HatTF;
    
    
    private void Start() {
        indexType = (int) ESkinType.Hat;
        HatTF = player.HatTF;
        
    }
   public override void SpawnSkin(ESkinType iType, int indexItem)
   {
        RefeshObj(HatTF);
        prefab = hatDatas.GetPrefab(indexItem);
        if(dictHat.ContainsKey(prefab))
        {
            dictHat[prefab].SetActive(true);
        }
        else
        {
            Hat = Instantiate(prefab, player.HatTF);
            dictHat.Add(prefab, Hat);
        }
   }

   public override void DespawnSkin(ESkinType iType, int indexItem)
   {
        prefab = hatDatas.GetPrefab(indexItem);
        dictHat[prefab].SetActive(false);
   }

   public override void Select()
   {
    PresentSkin.Instance.currentSkin = this;
   }

   

}
