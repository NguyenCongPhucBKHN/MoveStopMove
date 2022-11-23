using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CharacterData 
{
    [SerializeField] BodyMaterialDatas bodyMaterialDatas;
    private string name;
    private float score;
    private EBodyMaterialType eBodyMaterialType;
    private Material bodyMaterial;

    float scale;
    

    public CharacterData(string name, float vscore, EBodyMaterialType vname)
    {
        this.name= name;
        this.score = vscore;
        this.eBodyMaterialType = vname;
        // this.bodyMaterial = bodyMaterialDatas.GetMaterial(vname);
    }
    public void SetName(string vname)
    {
        this.name = vname;
    }
    public string GetName()
    {
        return this.name;
    }

    public void SetScore(float vscore)
    {
        this.score = vscore;
    }
    public float GetScore()
    {
        return this.score;
    }

    public void SetEBodyMaterialType(EBodyMaterialType vname)
    {
        this.eBodyMaterialType = vname;
    }
    public EBodyMaterialType GetEBodyMaterialType()
    {
        return this.eBodyMaterialType;
    }

    public void SetBodyMaterial(EBodyMaterialType eBodyMaterialType)
    {
         
        this.bodyMaterial = bodyMaterialDatas.GetMaterial(eBodyMaterialType);
    }
    public Material GetBodyMaterial()
    {
        return this.bodyMaterial;
    }
}
