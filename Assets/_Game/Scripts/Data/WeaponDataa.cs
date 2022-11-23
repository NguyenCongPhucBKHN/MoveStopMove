using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponDataa 
{
    [SerializeField] public ListWeaponMaterials listWeaponMaterials;
    private EWeaponType eWeaponType;
    private int indexMaterial;
    private List<Material> materials = new List<Material>();

    public void SetEWeaponType(int index)
    {
        this.eWeaponType = (EWeaponType) index;
    }
    public EWeaponType GetEWeaponType()
    {
        return this.eWeaponType;
    }

    public void SetIndexMaterial(int index)
    {
        this.indexMaterial= index;
    }
    public int GetIndexMaterial()
    {
        return this.indexMaterial;
    }

    public void SetMaterial()
    {
        List<Material> listMat= listWeaponMaterials.GetMaterial(this.eWeaponType, this.indexMaterial);
        for(int i =0; i< listMat.Count; i++)
        {
            materials.Add(listMat[i]);
        }
        
    }
    public List<Material> GetMaterial()
    {
        return this.materials;
    }
}
