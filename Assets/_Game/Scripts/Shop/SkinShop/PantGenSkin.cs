using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantGenSkin : GenSkin
{
    [SerializeField] private PantDatas data;
    private SkinnedMeshRenderer meshRenderer;
    private Material material;
     private void Awake() {
         PresentSkin.Instance.listGenSkin[1]=this;
         player= FindObjectOfType<Player>();
    }
     private void Start() 
     {

        indexType = (int) ESkinType.Pant;
        meshRenderer = player.pantRender;
        
    }
     public override void SpawnSkin(ESkinType indexType, int indexItem)
    {   
        material = data.GetMaterial(indexItem);
        if(material!=null && meshRenderer!=null)
        {
            meshRenderer.material = material;
        }
        
    }

    public override void DespawnSkin(ESkinType indexType, int indexItem)
    {
        
    }

    public override void Select()
    {
        PresentSkin.Instance.currentSkin = this;        
    }

}
