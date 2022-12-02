using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenSkin: GenSkin
{
    [SerializeField] ShieldDatas shieldData;
    private GameObject prefab;
    private GameObject shield;
    private Dictionary<GameObject, GameObject> dictHat = new Dictionary<GameObject, GameObject>();
    private Transform ShieldTF;
    
     private void Awake() {
         PresentSkin.Instance.listGenSkin[2]=this;
         player= FindObjectOfType<Player>();
    }
    private void Start() {
        indexType = (int) ESkinType.Shield;
        ShieldTF = player.ShieldTF;
         PresentSkin.Instance.listGenSkin[2]=this;
        
    }
   public override void SpawnSkin(ESkinType iType, int indexItem)
   {
        RefeshObj(ShieldTF);
        prefab = shieldData.GetPrefab(indexItem);
        if(prefab!=null)
        {
            if(dictHat.ContainsKey(prefab))
            {
                dictHat[prefab].SetActive(true);
            }
            else
            {
                shield = Instantiate(prefab, player.ShieldTF);
                dictHat.Add(prefab, shield);
            }
        }
   }

   public override void DespawnSkin(ESkinType iType, int indexItem)
   {
        prefab = shieldData.GetPrefab(indexItem);
        dictHat[prefab].SetActive(false);
   }

   public override void Select()
   {
    PresentSkin.Instance.currentSkin = this;
   }

}
